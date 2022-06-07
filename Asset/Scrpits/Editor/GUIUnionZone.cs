using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(UnionZone))]
public class GUIUnionZone : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        var ui = target as UnionZone;
        if (GUILayout.Button("UnionAtom")) {
            ui.UnionAtom();
        }
    }
}