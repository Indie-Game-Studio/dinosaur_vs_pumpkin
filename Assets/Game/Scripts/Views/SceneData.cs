using UnityEngine;

public class SceneData : MonoBehaviour {
    public Transform pumpkinSpawnPos;

    void Start() {
        GameEngine.SharedInstance().stage.OnLevelSceneLoaded(this);
    }
}