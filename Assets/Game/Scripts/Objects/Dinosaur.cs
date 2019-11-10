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
    RectTransform m_arrow;
    Animator m_animator;
    NavMeshAgent m_agent;
    StateMachine<States> m_fsm;

    void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_agent = GetComponent<NavMeshAgent>();
        m_fsm = StateMachine<States>.Initialize(this, States.Idle);
    }

    void Update()
    {
        if (m_arrow != null)
        {
            Vector3 self = Camera.main.WorldToViewportPoint(transform.position, Camera.MonoOrStereoscopicEye.Mono);
            Vector3 target = Camera.main.WorldToViewportPoint(m_target.position, Camera.MonoOrStereoscopicEye.Mono);

            bool show = !(self.x >= 0f && self.x <= 1f && self.y >= 0f && self.y <= 1f);
            if (show)
            {
                m_arrow.gameObject.SetActive(true);

                RectTransform camreaRT = m_arrow.root as RectTransform;
                Vector3 selfScreenPoint = Camera.main.ViewportToScreenPoint(self);

                Debug.Log(selfScreenPoint);

                selfScreenPoint.z = 0;
                if (selfScreenPoint.x < 0) selfScreenPoint.x = 20f;
                if (selfScreenPoint.x > Screen.width) selfScreenPoint.x = Screen.width - 20f;
                if (selfScreenPoint.y < 0) selfScreenPoint.y = 10f;
                if (selfScreenPoint.y > Screen.height) selfScreenPoint.y = Screen.height - 20f;

                Vector2 selfUIPosition;
                if (RectTransformUtility.ScreenPointToLocalPointInRectangle(camreaRT, selfScreenPoint, null, out selfUIPosition))
                {
                    m_arrow.anchoredPosition = selfUIPosition;
                }

                Vector3 dir = target - self;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 180f;
                m_arrow.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
            else {
                m_arrow.gameObject.SetActive(false);
            }
        }
    }

    public void SetArrow(RectTransform arrow)
    {
        m_arrow = arrow;
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
