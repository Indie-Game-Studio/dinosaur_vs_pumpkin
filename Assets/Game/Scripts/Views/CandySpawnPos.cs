using System;
using UnityEngine;

public enum CandySpawnPosType {
    /** 仅一次 */
    Once_Only,
    /** 固定时间间隔(无论糖果是否被接) */
    Fixed_Interval,
    /** 糖果被接后，固定时间后刷新 */
    Fixed_Timer,
}

[Serializable]
public class CandySpawnPos {
    /** 糖果刷新位置 */
    public Vector3 position = Vector3.zero;
    /** 刷新的类型 */
    public CandySpawnPosType type = CandySpawnPosType.Once_Only;
    /** 时间间隔参数 */
    public int interval = 0; 
    /** 是否有次数上限 */
    public bool maxLimit = false;
    /** 次数上限 */
    public int maxCount = 1;
}