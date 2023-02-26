using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EpisodeManager))]
public class EpisodeManagerEditor : Editor
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

        EpisodeManager man = target as EpisodeManager;
        if(man == null) {
            return;
        }

        GUILayout.BeginHorizontal();
        if(GUILayout.Button("Prev")) {
            man.prev();
        }
        if(GUILayout.Button("Next")) {
            man.next();
        }
        if(GUILayout.Button("Debug")) {
            man.LaunchDebugEpisode();
        };
        GUILayout.EndHorizontal();


        int currEpiIndex = man._currentEpisodeIndex;
        GenericEpisode currentEpi = man.getEpisode(currEpiIndex);
        string currentEpisodeName = currentEpi == null ? "null" : currentEpi.name;
        
        GUILayout.BeginHorizontal();
        GUILayout.Label("Current Episode");
        GUILayout.TextField(currEpiIndex.ToString());
        GUILayout.TextField(currentEpisodeName);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Current camera position");
        GUILayout.TextField(man._camDolly != null ? man._camDolly.targetName : "null");
        GUILayout.EndHorizontal();
    }
}
