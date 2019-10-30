using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class CandySpawner : MonoBehaviour {
    public float spawnInterval = 10;

    public int maxCandyCount = 3;

    private float _timeCounter = 0;

    public GameObject candyPrefab;

    public Transform pumpkin;

    // Start is called before the first frame update
    void Start() {
        if (candyPrefab == null) {
            Debug.LogError("Must specify candy prefabs for CandySpawner.");
        } else {
            CheckAndSpawnCandy();
        }

        pumpkin = FindObjectOfType<Pumpkin>().transform;
    }

    // Update is called once per frame
    void Update() {
        _timeCounter += Time.deltaTime;

        if (_timeCounter >= spawnInterval) {
            _timeCounter = 0;
            CheckAndSpawnCandy();
        }
    }

    private void CheckAndSpawnCandy() {
        while (true) {
            var candies = GetComponentsInChildren<Candy>();
            
            if (candies.Length >= maxCandyCount)
                break;

            do {
                var pos = GetRandomLocation();
                var dis = Vector3.Distance(pumpkin.position, pos); 
                if (dis <= 30)
                    continue;
                var tooClose = false;
                foreach (var candy in candies) {
                    tooClose = Vector3.Distance(candy.transform.position, pos) <= 30;
                    if (tooClose)
                        break;
                }

                if (tooClose)
                    continue;

                SpawnCandy(pos);
                break;
            } while (true);
        }
    }

    private void SpawnCandy(Vector3 pos) {
        Instantiate(candyPrefab, pos, Quaternion.identity, transform);
    }

    private Vector3 GetRandomLocation() {
        NavMeshTriangulation navMeshData = NavMesh.CalculateTriangulation();

        int t = Random.Range(0, navMeshData.indices.Length - 3);

        Vector3 point = Vector3.Lerp(navMeshData.vertices[navMeshData.indices[t]],
            navMeshData.vertices[navMeshData.indices[t + 1]], Random.value);
        point = Vector3.Lerp(point, navMeshData.vertices[navMeshData.indices[t + 2]], Random.value);

        return point;
    }
}