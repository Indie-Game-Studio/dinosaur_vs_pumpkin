using System;
using UnityEngine;
using UnityEditor;
using UnityEditor.OSXStandalone;

[CustomEditor(typeof(SceneData))]
public class SceneDataEditor: EditorWithSubEditors<CandySpawnPosEditor, CandySpawnPos> {
    private SerializedProperty propertyPumpkinSpawn;

    private SerializedProperty propertyCandySpawnCollection;

    private bool showPropertyPumpkinSpawn = true;

    private const string propertyPumpkinSpawnName = "pumpkinSpawnPos";
    private const string propertyCandySpawnCollectionName = "candySpawnPosCollection";

    private SceneData sceneData;

    private void OnEnable() {
        sceneData = (SceneData) target;
        
        if (sceneData.candySpawnPosArray == null)
            sceneData.candySpawnPosArray = new CandySpawnPos[0];
        
        propertyPumpkinSpawn = serializedObject.FindProperty(propertyPumpkinSpawnName);
        propertyCandySpawnCollection = serializedObject.FindProperty(propertyCandySpawnCollectionName);

        CheckAndCreateSubEditors(sceneData.candySpawnPosArray);
    }

    private void OnDisable() {
        CleanupEditors();
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

        // 南瓜怪出生点
        showPropertyPumpkinSpawn = EditorGUILayout.Foldout(showPropertyPumpkinSpawn, "南瓜怪出生点");
        if (showPropertyPumpkinSpawn) {
            EditorGUI.indentLevel++;
            if (sceneData.pumpkinSpawnPos == null) {
                if (GUILayout.Button("创建南瓜怪出生点")) {
                    sceneData.pumpkinSpawnPos = CreatePumpkinSpawn().transform;
                }                    
            } else {
                EditorGUILayout.PropertyField(propertyPumpkinSpawn);
            }
            EditorGUI.indentLevel--;
        }
        
        EditorGUILayout.Space();
        
        // 糖果刷新点
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("糖果刷新点");
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("+")) {
            
        }
        EditorGUILayout.EndHorizontal();
        
        for (int i = 0; i < subEditors.Length; i++) {
            subEditors[i].OnInspectorGUI();
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
    
    protected override void SubEditorSetup(CandySpawnPosEditor editor) {
    }
}