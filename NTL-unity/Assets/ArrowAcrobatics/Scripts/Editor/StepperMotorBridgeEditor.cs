using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StepperMotorBridge))]
public class StepperMotorBridgeEditor : Editor
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

        StepperMotorBridge component = target as StepperMotorBridge;

        if(component == null) {
            return;
        }

        if(GUILayout.Button("Reset serial")) {
            component.ResetSerial();
        };


        if(GUILayout.Button("Send debug message")) {
            component.SendString("hi from unity");
        };


    }
}
