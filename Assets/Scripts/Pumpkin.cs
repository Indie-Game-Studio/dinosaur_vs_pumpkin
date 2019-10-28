using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Pumpkin : MonoBehaviour {
    public float speed = 9;

    public float rotateSpeed = 60;
    
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Rotate (Vector3.up * -rotateSpeed * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            transform.Rotate (Vector3.up * rotateSpeed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.UpArrow)) {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        } 
    }
}