using System;
using UnityEngine;
using Object = UnityEngine.Object;

public enum CandySpawnPosType {
    /** 仅一次 */
    Once_Only,

    /** 固定时间间隔(无论糖果是否被接) */
    Fixed_Interval,

    /** 糖果被接后，固定时间后刷新 */
    Fixed_Timer,
}

public class CandySpawnPos : MonoBehaviour {
    /** 刷新的类型 */
    public CandySpawnPosType type = CandySpawnPosType.Once_Only;

    /** 时间间隔参数 */
    public int interval = 0;

    /** 是否有次数上限 */
    public bool maxLimit = false;

    /** 次数上限 */
    public int maxCount = 1;

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position + Vector3.up * 0.5f, 0.5f);
    }
}
