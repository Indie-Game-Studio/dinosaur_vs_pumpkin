using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {
    public Transform target;

    public float smoothSpeed = 10f;

    public Vector3 offset;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        var destPosition = target.position + offset;
        var smoothedPosition = Vector3.Lerp(transform.position, destPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}