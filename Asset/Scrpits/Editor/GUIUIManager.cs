using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(UIManager))]
public class GUIUIManager : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        var ui = target as UIManager;
        if (GUILayout.Button("setOrigin")) {
            var rectTrasform = ui.GetComponent<RectTransform>();

            rectTrasform.position = ui.originalPosition;
            var quaternion = Quaternion.Euler(ui.originalRotation.x, ui.originalRotation.y, ui.originalRotation.z);
            rectTrasform.rotation = quaternion;
        }

        if (GUILayout.Button("setKiosk")) {
            var rectTrasform = ui.GetComponent<RectTransform>();

            rectTrasform.position = ui.kioskPositon;
            var quaternion = Quaternion.Euler(ui.kioskRotation.x, ui.kioskRotation.y, ui.kioskRotation.z);
            rectTrasform.rotation = quaternion;
        }
    }
}