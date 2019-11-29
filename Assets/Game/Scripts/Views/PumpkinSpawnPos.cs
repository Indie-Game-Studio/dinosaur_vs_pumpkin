using System;
using UnityEngine;

public class PumpkinSpawnPos : MonoBehaviour {
#if UNITY_EDITOR
    private void OnDrawGizmos() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position + Vector3.up, 1f);
    }
#endif
}