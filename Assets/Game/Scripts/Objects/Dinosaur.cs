using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using MonsterLove.StateMachine;

public enum States
{
    Idle,
    Run,
    Attack
}

public class Dinosaur : MonoBehaviour
{
    public float attackRange = 3.5f;

    Transform m_target;
    Animator m_animator;
    NavMeshAgent m_agent;
    StateMachine<States> m_fsm;

    void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_agent = GetComponent<NavMeshAgent>();
        m_fsm = StateMachine<States>.Initialize(this, States.Idle);
    }

    public void SetTarget(Transform target)
    {
        m_target = target;
    }

    void Idle_Update()
    {
        if (m_target && m_agent.isOnNavMesh)
        {
            m_agent.isStopped = true;
            m_animator.SetFloat("moveSpeed", 0);
            float dis = Vector3.Distance(m_target.position, transform.position);
            if (dis >= attackRange)
            {
                m_fsm.ChangeState(States.Run);
            }
            else
            {
                m_fsm.ChangeState(States.Attack);
            }
        }
    }

    void Run_Update()
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
                m_fsm.ChangeState(States.Attack);
            }
        }
    }

    IEnumerator Attack_Enter()
    {
        //停止寻路
        m_agent.isStopped = true;

        //朝向目标
        transform.LookAt(m_target);

        //攻击动画
        m_animator.SetBool("attack", true);
        yield return new WaitForSeconds(1.24f);
        m_animator.SetBool("attack", false);
        yield return new WaitForSeconds(1f);

        //回到Idle
        m_fsm.ChangeState(States.Idle);
    }
}
