using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(MinMaxRangeAttribute))]
public class MinMaxRangeDrawer : PropertyDrawer {
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
        return base.GetPropertyHeight(property, label) + 16;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        if (property.type != "MinMaxRange")
            Debug.LogWarning("Use only with MinMaxRange type");
        else {
            var range = attribute as MinMaxRangeAttribute;
            var minValue = property.FindPropertyRelative("start");
            var maxValue = property.FindPropertyRelative("end");
            var newMin = minValue.floatValue;
            var newMax = maxValue.floatValue;

            var xDivision = position.width * 0.33f;
            var yDivision = position.height * 0.5f;
            EditorGUI.LabelField(new Rect(position.x, position.y, xDivision, yDivision), label);

            EditorGUI.LabelField(new Rect(position.x, position.y + yDivision, position.width, yDivision)
                , range.minLimit.ToString("0.##"));
            EditorGUI.LabelField(new Rect(position.x + position.width - 28f, position.y +
                                                                             yDivision, position.width, yDivision),
                range.maxLimit.ToString("0.##"));
            EditorGUI.MinMaxSlider(new Rect(position.x + 24f, position.y + yDivision, position.width - 48f, yDivision)
                , ref newMin, ref newMax, range.minLimit, range.maxLimit);

            EditorGUI.LabelField(new Rect(position.x + xDivision, position.y, xDivision, yDivision)
                , "From: ");
            newMin = Mathf.Clamp(EditorGUI.FloatField(new Rect(position.x + xDivision + 30, position.y,
                        xDivision - 30, yDivision)
                    , newMin)
                , range.minLimit, newMax);
            EditorGUI.LabelField(new Rect(position.x + xDivision * 2f, position.y, xDivision, yDivision)
                , "To: ");
            newMax = Mathf.Clamp(EditorGUI.FloatField(new Rect(position.x + xDivision * 2f + 24, position.y,
                        xDivision - 24, yDivision)
                    , newMax)
                , newMin, range.maxLimit);

            minValue.floatValue = newMin;
            maxValue.floatValue = newMax;
        }
    }
}