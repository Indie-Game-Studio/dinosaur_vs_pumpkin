using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dinosaur : MonoBehaviour
{
    public float attackRange = 3.5f;


    Transform m_target;
    Animator m_animator;
    NavMeshAgent m_agent;
    bool isAttacking = false;

    void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_target && m_agent.isOnNavMesh)
        {
            float dis = Vector3.Distance(m_target.position, transform.position);
            if (dis >= attackRange)
            {
                m_agent.isStopped = false;
                m_agent.SetDestination(m_target.position);
                m_animator.SetFloat("moveSpeed", m_agent.speed);
            }
            else
            {
                m_agent.isStopped = true;
                m_animator.SetFloat("moveSpeed", 0);

                if (!isAttacking) {
                    Attack();
                }
            }
        }
    }

    public void SetTarget(Transform target)
    {
        m_target = target;
    }

    void Attack() {
        isAttacking = true;
        transform.LookAt(m_target);
        m_animator.SetBool("attack", true);
        StartCoroutine("AttackLater");
    }

    IEnumerator AttackLater() {
        yield return new WaitForSeconds(1.24f);
        m_animator.SetBool("attack", false);
        yield return new WaitForSeconds(1f);
        isAttacking = false;
    }
}
