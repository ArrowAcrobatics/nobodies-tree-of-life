using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StepperMotorEditor))]
public class StepperMotorEditor : Editor
{
    public static void DrawUILine(Color color, int thickness = 2, int padding = 10) {
        Rect r = EditorGUILayout.GetControlRect(GUILayout.Height(padding+thickness));
        r.height = thickness;
        r.y+=padding/2;
        EditorGUI.DrawRect(r, color);
    }

    public override void OnInspectorGUI() {
        DrawDefaultInspector();
        DrawUILine(Color.gray);

        StepperMotor component = target as StepperMotor;

        if(component == null) {
            return;
        }

        GUILayout.BeginHorizontal();
        if(GUILayout.Button("Force lowerbound")) {
            component.ForceLowerbound();
        }
        if(GUILayout.Button("Force upperbound")) {
            component.ForceUpperBound();
        }
        if(GUILayout.Button("Reset bounds")) {
            component.ResetBounds();
        };
        GUILayout.EndHorizontal();
    }
}
