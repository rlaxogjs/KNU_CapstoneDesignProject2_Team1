using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(AtomRoot))]
public class GUIAtomRoot : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        var ui = target as AtomRoot;
        if (GUILayout.Button("Create Atom")) {
            var info = AtomInfo.getAtomInfo(ui.spawnType);

            ui.spawnAtom(info);
        }
    }
}