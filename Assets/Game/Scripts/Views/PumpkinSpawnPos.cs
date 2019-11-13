using UnityEngine;

public class PumpkinSpawnPos : MonoBehaviour {
    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + Vector3.up, 1f);
    }
}