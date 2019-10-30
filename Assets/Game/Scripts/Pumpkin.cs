using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

//[RequireComponent(typeof(NavMeshAgent))]
public class Pumpkin : MonoBehaviour {
    public float rotateSpeed = 60;

    public float speed = 9;

//    private NavMeshAgent _agent;
    
    // Start is called before the first frame update
    void Start() {
//        _agent = GetComponent<NavMeshAgent>();
//        _agent.velocity = Vector3.forward * _agent.speed;
//        _agent.isStopped = false;
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

    public void ReceiveCandy(Candy candy) {
        Debug.LogFormat("Received candy: {0}", candy.color);
    }
}