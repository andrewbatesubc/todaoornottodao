using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaoziEventHandler : EventHandlerParent
{
    public GameObject firstSelectionCanvas;
    public GameObject secondSelectionCanvas;
    public GameObject exitCanvas;
    public Text secondSelectionCanvasText;
    public GameObject objects;
    public PlayerChoiceManager manager;
    public Fade fader;

    public override void HandleNextStep(string message, int subEventIndex) {
        if (subEventIndex == 0) {
            StartCoroutine(NextStepRoutine(message));
        }
    }

    IEnumerator NextStepRoutine(string message) {
        yield return StartCoroutine(fader.FadeToBlack());
        secondSelectionCanvasText.text = message;
        firstSelectionCanvas.SetActive(false);
        secondSelectionCanvas.SetActive(true);
        objects.SetActive(false);
        yield return StartCoroutine(fader.FadeFromBlack());
    }

    public void FromSecondToThird() {
        secondSelectionCanvas.SetActive(false);
        exitCanvas.SetActive(true);
    }

    public void FromThirdToExit()
    {
        exitCanvas.SetActive(false);
    }
}
