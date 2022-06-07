using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUIManager : MonoBehaviour
{
    public int thisPanelIndex;

    public GameObject[] panels;

    public Button prevButton;
    public Button nextButton;

    public GameObject lineOfSight;

    void Start()
    {
        thisPanelIndex = 0;
        prevButton.interactable = false;
        foreach(var gb in panels) {
            gb.SetActive(false);
        }
        panels[thisPanelIndex].SetActive(true);
    }

    public void onNextButtonCliecked() {
        if (thisPanelIndex >= 3) return;

        panels[thisPanelIndex].SetActive(false);
        thisPanelIndex++;
        panels[thisPanelIndex].SetActive(true);

        if (thisPanelIndex >= 3)
            nextButton.interactable = false;
        prevButton.interactable = true;
    }

    public void onPreveButtonClicked() {
        if (thisPanelIndex <= 0) return;

        panels[thisPanelIndex].SetActive(false);
        thisPanelIndex--;
        panels[thisPanelIndex].SetActive(true);

        if (thisPanelIndex <= 0)
            prevButton.interactable = false;
        nextButton.interactable = true;
    }

    public void onStartButtonClicked() {
        gameObject.SetActive(false);
        lineOfSight.SetActive(true);
    }


    void Update()
    {
        
    }
}
