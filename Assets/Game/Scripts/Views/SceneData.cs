using System;
using UnityEngine;

public class SceneData : MonoBehaviour {
    public Vector3 pumpkinSpawnPos = Vector3.zero;
    
#if UNITY_EDITOR
    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(pumpkinSpawnPos + Vector3.up, 1f);
    }
#endif

    void Start() {
        GameEngine.SharedInstance().stage.OnLevelSceneLoaded(this);
    }
}