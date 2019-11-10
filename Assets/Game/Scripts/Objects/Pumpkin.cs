using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumpkin : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSmoothing = 15f;

    Rigidbody m_rigid;
    Animator m_animator;
    
    void Awake()
    {
        m_rigid = GetComponent<Rigidbody>();
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        bool acc = Input.GetKey(KeyCode.LeftShift);
        if (h != 0f || v != 0f)
        {
            Moving(h, v, acc);
            Rotating(h, v);
            float moveSpeed = h * h + v * v;
            m_animator.SetFloat("moveSpeed", moveSpeed);
        }
        else {
            m_animator.SetFloat("moveSpeed", 0f);
        }
    }

    void Rotating(float horizontal, float vertical)
    {
        Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        Quaternion newRotation = Quaternion.Lerp(m_rigid.rotation, targetRotation, turnSmoothing * Time.deltaTime);
        m_rigid.MoveRotation(newRotation);
    }
    void Moving(float horizontal, float vertical,bool acc) {
        Vector3 deltaPos = new Vector3(horizontal, 0f, vertical);
        Vector3 newPosition = m_rigid.position + deltaPos * (acc ? moveSpeed * 5 : moveSpeed) * Time.deltaTime;
        m_rigid.MovePosition(newPosition);
    }
}
