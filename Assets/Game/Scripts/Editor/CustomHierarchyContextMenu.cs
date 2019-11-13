#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class CustomHierarchyContextMenu {
    static bool _MenuOpened = false;
    static GameObject _ClickedObject = null;
    static Vector2 _MenuPosition;

    static CustomHierarchyContextMenu() {
//        EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyGUI;
    }

//    static void OnHierarchyGUI(int instanceID, Rect selectionRect) {
//        // Whether this object was right clicked
//        if (Event.current != null && selectionRect.Contains(Event.current.mousePosition)
//                                  && Event.current.button == 1 && Event.current.type <= EventType.MouseUp) {
//            // Find what object this is
//            GameObject clickedObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
//
//            if (clickedObject) {
//                _ClickedObject = clickedObject;
//                _MenuPosition = Event.current.mousePosition;
//                _MenuOpened = true;
//                // Consume the event to remove Unity's default context menu
//                Event.current.Use();
//            }
//        }
//
//        if (_MenuOpened) {
//            if (GUI.Button(new Rect(_MenuPosition.x, _MenuPosition.y, 150, 20f), "Delete")) {
//                _MenuOpened = false;
//                GameObject.Destroy(_ClickedObject);
//            }
//        }
//    }
}

#endif