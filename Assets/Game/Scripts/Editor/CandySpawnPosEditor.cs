using System;
using UnityEditor;

[CustomEditor(typeof(CandySpawnPos))]
public class CandySpawnPosEditor : Editor {

    private SerializedProperty propertyPosition; 
    
    private const String propertyPositionName = "position";

    private void OnEnable() {
        propertyPosition = serializedObject.FindProperty(propertyPositionName);
    }

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
    }
}