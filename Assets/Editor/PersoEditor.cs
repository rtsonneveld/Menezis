using UnityEngine;
using System.Collections;
using UnityEditor;
using Menezis;

[CustomEditor(typeof(Perso), true)]
public class MyTypeEditor : Editor {
    public override void OnInspectorGUI()
    {

        Perso persoTarget = (Perso)target;
        EditorGUILayout.LabelField("Active Rule: "+persoTarget.ActiveRule);
        EditorGUILayout.LabelField("Active Reflex: " + persoTarget.ActiveReflex);

        DrawDefaultInspector();
    }
}