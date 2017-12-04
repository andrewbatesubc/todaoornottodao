using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverEventHandler : MonoBehaviour {

    public GameObject destinationObject;
    public PlayerChoiceManager manager;
    public PlayerMovement movement;
    public Fade fader;
    public GameObject blockerObject;
    public GameObject canvasObject;
    public GameObject newBlockerObjects;
    public GameObject newCanvas;

    bool isSelected = false;

    public void HandleJumpIntoRiver() {
        if (!isSelected) {
            StartCoroutine(CrossRiver());
        }
    }

    public void HandleGourd()
    {
        if (!isSelected && PlayerChoiceManager.GetInstance().IsDecisionSatisfied("Gourd"))
        {
            StartCoroutine(CrossRiver());
        }
    }

    public void HandleRug()
    {
        if (!isSelected && PlayerChoiceManager.GetInstance().IsDecisionSatisfied("SkippedMeat"))
        {
            StartCoroutine(CrossRiver());
        }
    }

    IEnumerator CrossRiver() {
        isSelected = true;
        yield return StartCoroutine(movement.FadeAndMove(destinationObject.transform.position, new GameObject[] { blockerObject, canvasObject}));
        newBlockerObjects.SetActive(true);
        newCanvas.SetActive(true);
        isSelected = false;
    }
}
