using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SicknessEventHandler : MonoBehaviour {

    public GameObject blockerObjects;
    public GameObject canvas;

    public Fade fader;

    private bool isSelected = false;

    public void HandleEatMeat()
    {
        if (!isSelected && PlayerChoiceManager.GetInstance().IsDecisionSatisfied("KeepMeat"))
        {
            StartCoroutine(RoutineHelper(new GameObject[] { blockerObjects, canvas }, new GameObject[] { }));
        }
    }

    public void HandlePonder()
    {
        if (!isSelected)
        {
            StartCoroutine(RoutineHelper(new GameObject[] { blockerObjects, canvas }, new GameObject[] { }));
        }
    }


    IEnumerator RoutineHelper(GameObject[] objectsToDisable, GameObject[] objectsToEnable)
    {
        isSelected = true;
        yield return StartCoroutine(fader.FadeToBlack());
        foreach (GameObject go in objectsToDisable)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in objectsToEnable)
        {
            go.SetActive(true);
        }
        yield return StartCoroutine(fader.FadeFromBlack());
        isSelected = false;
    }
}
