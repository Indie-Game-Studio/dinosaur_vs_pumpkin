using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CandyColor {
    BLUE,
    RED,
    GREEN,
}

[RequireComponent(typeof(Collider))]
public class Candy : MonoBehaviour {
    public CandyColor color = CandyColor.BLUE;
    
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }

    void OnTriggerEnter(Collider other) {
        var pumpkin = other.GetComponent<Pumpkin>();
        if (pumpkin != null) {
            pumpkin.ReceiveCandy(this);
        }
    }
}