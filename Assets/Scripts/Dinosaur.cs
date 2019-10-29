using UnityEngine;
using UnityEngine.AI;

enum DinosaurState {
    Normal,
    Tired,
    Idle,
    Scared,
}

[RequireComponent(typeof(NavMeshAgent))]
public class Dinosaur : MonoBehaviour {

    public float normalDuration = 10;

    public float restDuration = 2;

    public float speed = 10;

    public Transform target;

    private float _elapsed = 0;

    private DinosaurState _state = 0;

    private NavMeshAgent _agent;
    
    // Start is called before the first frame update
    void Start() {
        _state = DinosaurState.Normal;

        _agent = GetComponent<NavMeshAgent>();
        _agent.stoppingDistance = 5;

        var pumpkin = GameObject.FindObjectOfType<Pumpkin>();
        if (pumpkin != null)
            target = pumpkin.transform;
    }

    // Update is called once per frame
    void Update() {
        if (_state != DinosaurState.Idle) {
            _elapsed += Time.deltaTime;

            if (_state == DinosaurState.Normal) {
                if (_elapsed >= normalDuration) {
                    changeToState(DinosaurState.Tired);
                }
            } else if (_state == DinosaurState.Tired) {
                if (_elapsed >= restDuration) {
                    changeToState(DinosaurState.Normal);
                }
            }
        }

        if (_state == DinosaurState.Normal && target != null) {
            _agent.isStopped = false;
            _agent.destination = target.position;
//            var targetPosition = target.position;
//            var targetRotation = Quaternion.LookRotation(targetPosition - transform.position, Vector3.up);
//            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);

//            transform.LookAt(target, Vector3.up); 
//            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        } else {
            _agent.isStopped = true;
        }
    }

    void changeToState(DinosaurState st) {
        _state = st;
        _elapsed = 0;
    }
}