using UnityEngine;

public class BodyObject : MonoBehaviour {
    public float radius = 3f;

    public float height = 0f;

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + Vector3.up * (height / 2), radius);
    }
}