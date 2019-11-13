using UnityEditor;
using UnityEngine;

public class SceneData : MonoBehaviour {
    public Transform pumpkinSpawnPos;

    void Start() {
        GameEngine.SharedInstance().stage.OnLevelSceneLoaded(this);
    }

#if UNITY_EDITOR
     // GameObject的menu中的priority低于50的item同样会出现在Hierarchy的Context Menu中
    [MenuItem("GameObject/Create SceneData", priority = 49)]
    public static void CreateSceneDataObject() {
        var obj = new GameObject("SceneData");
        obj.AddComponent<SceneData>();
    }
#endif
}