using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SceneData))]
public class SceneDataEditor: Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
    }
}