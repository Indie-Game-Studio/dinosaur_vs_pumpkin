using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage : MonoBehaviour, ILevelSceneEventHandle {
    public GameObject arrowPre;
    public GameObject pumpkinPre;
    public GameObject dinosaurPre;
    public CameraFollower cameraFollower;

    Scene m_scene;
    GameObject m_pumpkin;
    GameObject m_dinosaur;

    void Start() {
        GameEngine.SharedInstance().SetStage(this);
        LoadLevel("Level0");
    }

    void LoadLevel(string name) {
        if (m_pumpkin != null) {
            Destroy(m_pumpkin);
        }

        if (m_dinosaur != null) {
            Destroy(m_dinosaur);
        }

        if (m_scene.IsValid()) {
            SceneManager.UnloadSceneAsync(m_scene);
        }

        LoadSceneParameters args = new LoadSceneParameters() {
            loadSceneMode = LoadSceneMode.Additive
        };
        m_scene = SceneManager.LoadScene(name, args);
    }

    GameObject CreateObject(GameObject prefab) {
        Vector3 pos = new Vector3();
        pos.x = Random.Range(-20 * 5f, 20 * 5f);
        pos.z = Random.Range(-20 * 5f, 20 * 5f);

        return CreateObject(prefab, pos);
    }

    GameObject CreateObject(GameObject prefab, Vector3 pos) {
        var obj = Instantiate(prefab);
        obj.transform.position = pos;
        return obj;
    }

    public void OnLevelSceneLoaded(SceneData scene) {
        m_pumpkin = CreateObject(pumpkinPre, scene.pumpkinSpawnPos);
        m_dinosaur = CreateObject(dinosaurPre);
        cameraFollower.SetTarget(m_pumpkin.transform);
        
        var arrow = Instantiate(arrowPre, arrowPre.transform.parent);
        arrow.SetActive(true);

        m_dinosaur.GetComponent<Dinosaur>().SetTarget(m_pumpkin.transform);
        m_dinosaur.GetComponent<Dinosaur>().SetArrow(arrow.transform as RectTransform);
    }
}