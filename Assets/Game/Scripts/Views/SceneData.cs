using System;
using UnityEngine;
using UnityEngine.Serialization;

public class SceneData : MonoBehaviour {
    public Transform pumpkinSpawnPos;

    public CandySpawnPos[] candySpawnPosArray = new CandySpawnPos[0];
    
    void Start() {
        GameEngine.SharedInstance().stage.OnLevelSceneLoaded(this);
    }
}