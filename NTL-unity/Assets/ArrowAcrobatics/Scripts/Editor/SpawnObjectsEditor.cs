using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpawnObjects))]
public class SpawnObjectsEditor : Editor
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

        SpawnObjects spawner = target as SpawnObjects;
        if(spawner == null) {
            return;
        }

        GUILayout.BeginHorizontal();
        if(GUILayout.Button("respawn")) {
            spawner.Spawn();
        }
        if(GUILayout.Button("clear")) {
            spawner.Clear();
        }
        GUILayout.EndHorizontal();
    }
}
