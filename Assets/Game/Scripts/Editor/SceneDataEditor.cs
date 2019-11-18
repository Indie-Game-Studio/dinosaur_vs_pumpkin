using System;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(SceneData))]
public class SceneDataEditor: Editor {
    private SerializedProperty propertyPumpkinSpawn;

    private bool showPropertyPumpkinSpawn = true;

    private const string propertyPumpkinSpawnName = "pumpkinSpawnPos";

    private SceneData sceneData;

    private void OnEnable() {
        sceneData = (SceneData) target;
        propertyPumpkinSpawn = serializedObject.FindProperty(propertyPumpkinSpawnName);
    }

    // GameObject的menu中的priority低于50的item同样会出现在Hierarchy的Context Menu中
    [MenuItem("GameObject/Create SceneData", priority = 49)]
    public static void CreateSceneDataObject() {
        var obj = new GameObject("SceneData");
        obj.AddComponent<SceneData>();
        Undo.RegisterCreatedObjectUndo(obj, "Create SceneData");
//        Undo.AddComponent<SceneData>(obj);
//        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }
    
    public override void OnInspectorGUI() {
        serializedObject.Update();
        
        EditorGUILayout.LabelField("场景数据");
        EditorGUILayout.Space();

        showPropertyPumpkinSpawn = EditorGUILayout.Foldout(showPropertyPumpkinSpawn, "南瓜怪出生点");
        if (showPropertyPumpkinSpawn) {
            EditorGUI.indentLevel++;
            if (sceneData.pumpkinSpawnPos == null) {
                if (GUILayout.Button("创建 南瓜怪出生点")) {
                    sceneData.pumpkinSpawnPos = CreatePumpkinSpawn().transform;
                    Repaint();
                }
            } else {
                EditorGUILayout.PropertyField(propertyPumpkinSpawn);
            }
            EditorGUI.indentLevel--;
        }
        EditorGUILayout.Space();
    }

    private GameObject CreatePumpkinSpawn() {
        GameObject obj = new GameObject("pumpkin spawn");
        obj.AddComponent<PumpkinSpawnPos>();
        obj.transform.parent = ((SceneData) target).transform;
        Undo.RegisterCreatedObjectUndo(obj, "Pumpkin Spawn Object");
        return obj;
    }
}