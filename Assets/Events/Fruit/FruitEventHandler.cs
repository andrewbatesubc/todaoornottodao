using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitEventHandler : EventHandlerParent {

    public GameObject firstSelectionCanvas;
    public GameObject secondSelectionCanvas;
    public GameObject beforeOutroCanvas;
    public Text beforeOutroCanvasText;
    public GameObject outroCanvas;
    public GameObject blockerObjects;
    public GameObject fruitTree;
    public PlayerChoiceManager manager;
    public Fade fader;
    public GameObject cookObjects;

    bool isSelected = false;

    [TextArea]
    public string carvedBasinText;
    [TextArea]
    public string carvedDipperText;
    [TextArea]
    public string uncarvedWoodText;


    public override void HandleNextStep(string message, int subEventIndex)
    {
        StartCoroutine(NextStepRoutine(message));
    }

    public void HandleSelectedFruitFound()
    {
        if (!isSelected)
        {
            StartCoroutine(FruitFoundRoutine());
        }
    }

    IEnumerator FruitFoundRoutine()
    {
        isSelected = true;
        yield return StartCoroutine(fader.FadeToBlack());
        firstSelectionCanvas.SetActive(false);
        secondSelectionCanvas.SetActive(true);
        fruitTree.SetActive(true);
        yield return StartCoroutine(fader.FadeFromBlack());
        isSelected = false;
    }

    public void HandleSelectedDoNothingWithSeeds()
    {
        if (!isSelected)
        {
            StartCoroutine(FruitSkippedRoutine());
        }

    }

    IEnumerator FruitSkippedRoutine()
    {
        isSelected = true;
        yield return StartCoroutine(fader.FadeToBlack());
        firstSelectionCanvas.SetActive(false);
        outroCanvas.SetActive(true);
        yield return StartCoroutine(fader.FadeFromBlack());
        isSelected = false;
    }

    public void HandleCarveBasin()
    {
        if (!isSelected)
        {
            StartCoroutine(BasinRoutine());
        }
    }

    IEnumerator BasinRoutine()
    {
        isSelected = true;
        yield return StartCoroutine(fader.FadeToBlack());
        secondSelectionCanvas.SetActive(false);
        beforeOutroCanvas.SetActive(true);
        beforeOutroCanvasText.text = carvedBasinText;
        yield return StartCoroutine(fader.FadeFromBlack());
        isSelected = false;
    }

    public void HandleCarveDipper()
    {
        if (!isSelected)
        {
            StartCoroutine(DipperRoutine());
        }
    }

    IEnumerator DipperRoutine()
    {
        isSelected = true;
        yield return StartCoroutine(fader.FadeToBlack());
        secondSelectionCanvas.SetActive(false);
        beforeOutroCanvas.SetActive(true);
        beforeOutroCanvasText.text = carvedDipperText;
        yield return StartCoroutine(fader.FadeFromBlack());
        isSelected = false;
    }

    public void HandleDontCarve()
    {
        if (!isSelected)
        {
            StartCoroutine(DontCarveRoutine());
        }
    }

    IEnumerator DontCarveRoutine()
    {
        isSelected = true;
        yield return StartCoroutine(fader.FadeToBlack());
        secondSelectionCanvas.SetActive(false);
        beforeOutroCanvas.SetActive(true);
        beforeOutroCanvasText.text = uncarvedWoodText;
        yield return StartCoroutine(fader.FadeFromBlack());
        isSelected = false;
    }

    public void HandleLeadToOutro()
    {
        if (!isSelected)
        {
            StartCoroutine(LeadToOutroRoutine());
        }
    }

    IEnumerator LeadToOutroRoutine()
    {
        isSelected = true;
        yield return StartCoroutine(fader.FadeToBlack());
        beforeOutroCanvas.SetActive(false);
        outroCanvas.SetActive(true);
        yield return StartCoroutine(fader.FadeFromBlack());
        isSelected = false;
    }

    IEnumerator NextStepRoutine(string message)
    {
        isSelected = true;
        yield return StartCoroutine(fader.FadeToBlack());
        beforeOutroCanvasText.text = message;
        firstSelectionCanvas.SetActive(false);
        secondSelectionCanvas.SetActive(true);
        blockerObjects.SetActive(false);
        yield return StartCoroutine(fader.FadeFromBlack());
        isSelected = false;
    }

    public void FromSecondToThird()
    {
        if (!isSelected)
        {
            isSelected = true;
            secondSelectionCanvas.SetActive(false);
            outroCanvas.SetActive(true);
            isSelected = false;
        }

    }

    public void AllFinished() {
        if (!isSelected)
        {
            isSelected = true;
            outroCanvas.SetActive(false);
            blockerObjects.SetActive(false);
            cookObjects.SetActive(true);
            isSelected = false;
        }
    }

    public void FromThirdToExit()
    {
        if (!isSelected)
        {
            isSelected = true;
            outroCanvas.SetActive(false);
            isSelected = false;
        }
    }
}
