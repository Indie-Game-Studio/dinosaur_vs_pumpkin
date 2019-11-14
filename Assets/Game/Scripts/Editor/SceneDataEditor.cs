using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(SceneData))]
public class SceneDataEditor: Editor {
    
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
        base.OnInspectorGUI();
    }
}