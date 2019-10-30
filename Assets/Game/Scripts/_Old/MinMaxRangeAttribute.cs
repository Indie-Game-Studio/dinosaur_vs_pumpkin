using UnityEngine;

public class MinMaxRangeAttribute : PropertyAttribute {
    public readonly float minLimit;
    public readonly float maxLimit;

    public MinMaxRangeAttribute(float min, float max) {
        minLimit = min;
        maxLimit = max;
    }
}

[System.Serializable]
public class MinMaxRange {
    public float start, end;

    public MinMaxRange(float s, float e) {
        start = s;
        end = e;
    }
}