using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIMotor : MonoBehaviour {

    public Transform target;

    private NavMeshAgent _agent;
    
    // Start is called before the first frame update
    void Start() {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update() {
        if (target != null) {
            _agent.SetDestination(target.position);
        }
    }

    public void FollowTarget(BodyObject body) {
        _agent.stoppingDistance = body.radius;
        target = body.transform;
    }

    public void StopFollowing() {
        target = null;
    }
}