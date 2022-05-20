using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    public UIMenu uiMenu;
    public UISpawnAtom uiSpawnAtom;
    public UIAnalysis uiAnalysis;
    public UIDict uiDict;

    public GameObject currentUI;

    private void Awake() {
        if(instance == null) {
            instance = this;
        } else {
            Debug.Log("UIManager Instance ERRROR");
        }
    }

    public void changeUIComponent(GameObject target) {
        currentUI.SetActive(false);
        currentUI = target;
        currentUI.SetActive(true);
    }

}
