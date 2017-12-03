using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PointerChoice : MonoBehaviour {

    Image background;
    public Color highlightedColor;
    public Color originalColor;
    public Color invalidSelectionColor;
    public string choiceDependency = "";
    public string choiceMade = "";
    [TextArea]
    public string choiceMessage = "";
    public float fadeSpeed = 0.1f;
    public float fadeDelay = 0.02f;

    public float zuangziPointsAdded = 0.0f;
    public float laoziPointsAdded = 0.0f;
    public float fangshiPointsAdded = 0.0f;

    public AudioSource soundSource;
    public AudioClip soundEffect;

    private PlayerChoiceManager manager;
    public EventHandlerParent eventHandler;

    private int subEventIndex = 0;
    private bool isSelectable = true;
    public bool isValid = true;

    public void RefreshDependencies() {
        background = GetComponent<Image>();
        manager = PlayerChoiceManager.GetInstance();
        if (choiceDependency != "" && !manager.IsDecisionSatisfied(choiceDependency))
        {
            background.color = invalidSelectionColor;
            isValid = false;
        }
    }

    public void HandlePointerEnter()
    {
        if (isValid)
        {
            StartCoroutine(TransitionToHighlightedColor(fadeSpeed));
        }
    }

    public void HandlePointerExit()
    {
        if (isValid)
        {
            StartCoroutine(TransitionFromHighlightedColor(fadeSpeed));
        }
    }

    public void HandlePointerClick()
    {
        if (isValid)
        {
            manager = PlayerChoiceManager.GetInstance();
            isSelectable = false;
            manager.SetDecision(choiceMade);
            manager.AddZuangziPoints(zuangziPointsAdded);
            manager.AddFangshiPoints(fangshiPointsAdded);
            manager.AddLaoziPoints(laoziPointsAdded);
            if (soundSource != null && soundEffect) {
                soundSource.PlayOneShot(soundEffect);
            }
            StartCoroutine(ClickAnimation(fadeSpeed * 2));
            eventHandler.HandleNextStep(choiceMessage, subEventIndex);
            subEventIndex++;
        }
    }

    public void HandleUpdatePoints()
    {
        if (isValid)
        {
            manager = PlayerChoiceManager.GetInstance();
            isSelectable = false;
            manager.SetDecision(choiceMade);
            manager.AddZuangziPoints(zuangziPointsAdded);
            manager.AddFangshiPoints(fangshiPointsAdded);
            manager.AddLaoziPoints(laoziPointsAdded);
            if (soundSource != null && soundEffect)
            {
                soundSource.PlayOneShot(soundEffect);
            }
            StartCoroutine(ClickAnimation(fadeSpeed * 2));
            subEventIndex++;
        }
    }

    public IEnumerator ClickAnimation(float fadeSpeed) {
        yield return StartCoroutine(TransitionFromHighlightedColor(fadeSpeed));
        yield return StartCoroutine(TransitionToHighlightedColor(fadeSpeed));
    }

    public IEnumerator TransitionToHighlightedColor(float fadeSpeed)
    {
        background = GetComponent<Image>();
        float lerpValue = 0.0f;
        while (lerpValue < 1.0f)
        {
            lerpValue += fadeSpeed;
            background.color = Color.Lerp(originalColor, highlightedColor, lerpValue);
            yield return new WaitForSeconds(fadeDelay);
        }
    }

    public IEnumerator TransitionFromHighlightedColor(float fadeSpeed)
    {
        background = GetComponent<Image>();
        float lerpValue = 0.0f;
        while (lerpValue < 1.0f)
        {
            lerpValue += fadeSpeed;
            background.color = Color.Lerp(highlightedColor, originalColor, lerpValue);
            yield return new WaitForSeconds(fadeDelay);
        }
    }
}
