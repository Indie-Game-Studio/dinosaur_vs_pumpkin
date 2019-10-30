using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage : MonoBehaviour
{
    public GameObject pumpkinPre;
    public GameObject dinosaurPre;
    public CameraFollower cameraFollower;


    GameObject m_pumpkin;
    GameObject m_dinosaur;

    void Start()
    {
        LoadLevel("Level0");
    }

    void LoadLevel(string name) {
        LoadSceneParameters args = new LoadSceneParameters() {
            loadSceneMode = LoadSceneMode.Additive
        };
        Scene scene = SceneManager.LoadScene(name, args);

        m_pumpkin = Instantiate(pumpkinPre);
        m_dinosaur = Instantiate(dinosaurPre);

        cameraFollower.SetTarget(m_pumpkin.transform);
    }
}
