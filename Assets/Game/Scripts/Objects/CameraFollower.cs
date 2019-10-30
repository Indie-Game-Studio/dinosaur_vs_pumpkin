using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public float smoothSpeed = 10f;
    public Vector3 offset;

    Transform m_target;

    public void SetTarget(Transform target)
    {
        m_target = target;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var destPosition = m_target.position + offset;
        var smoothedPosition = Vector3.Lerp(transform.position, destPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
