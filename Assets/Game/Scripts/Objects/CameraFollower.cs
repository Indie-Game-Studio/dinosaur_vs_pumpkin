using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    Transform m_target;

    public float smoothSpeed = 10f;
    public Vector3 offset;

    // Start is called before the first frame update
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
