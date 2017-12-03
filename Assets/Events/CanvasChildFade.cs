using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasChildFade : MonoBehaviour {

    Image[] imagesToFade;
    Text[] textToFade;
    Image backgroundImage;

    public GameObject elementsParent;
    public float fadeSpeed = 0.1f;
    public float fadeDelay = 0.02f;

    public float baseTextAlpha = 1.0f;
    public float baseImageAlpha = 0.25f;
    public float baseBackgroundImageAlpha = 0.92f;

    private void Awake()
    {
        imagesToFade = elementsParent.GetComponentsInChildren<Image>();
        textToFade = elementsParent.GetComponentsInChildren<Text>();
        backgroundImage = GetComponent<Image>();
        foreach (Image img in imagesToFade)
        {
            img.color = new Color(img.color.r, img.color.g, img.color.b, 0);
        }

        foreach (Text txt in textToFade)
        {
            txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, 0);
        }

        backgroundImage.color = new Color(backgroundImage.color.r, backgroundImage.color.g, backgroundImage.color.b, 0);

        elementsParent.SetActive(false);
    }
    
    public void FadeInChildren()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeOutChildren()
    {
        StartCoroutine(FadeOut());
    }

    public IEnumerator FadeIn()
    {
        elementsParent.SetActive(true);
        PointerChoice[] choices = elementsParent.GetComponentsInChildren<PointerChoice>();
        if (choices != null) {
            Debug.Log("Did it hey?");
            foreach (PointerChoice pc in choices) {
                pc.RefreshDependencies();
            }
        }
        float currentTextAlpha = 0.0f;
        float currentImageAlpha = 0.0f;
        float currentBackgroundAlpha = 0.0f;

        while (currentTextAlpha < 1.0f)
        {
            currentImageAlpha += (fadeSpeed * baseImageAlpha);
            foreach (Image img in imagesToFade)
            {
                img.color = new Color(img.color.r, img.color.g, img.color.b, currentImageAlpha);
            }

            currentTextAlpha += (fadeSpeed * baseTextAlpha);
            foreach (Text txt in textToFade)
            {
                txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, currentTextAlpha);
            }
            currentBackgroundAlpha += (fadeSpeed * baseBackgroundImageAlpha);
            backgroundImage.color = new Color(backgroundImage.color.r, backgroundImage.color.g, backgroundImage.color.b, currentBackgroundAlpha);
            yield return new WaitForSeconds(fadeDelay);
        }
    }

    public IEnumerator FadeOut()
    {
        float currentTextAlpha = baseTextAlpha;
        float currentImageAlpha = baseImageAlpha;
        float currentBackgroundAlpha = baseBackgroundImageAlpha;
        while (currentTextAlpha >= 0.0f)
        {
            currentTextAlpha -= (fadeSpeed * baseTextAlpha);
            currentImageAlpha -= (fadeSpeed * baseImageAlpha);
            foreach (Image img in imagesToFade)
            {
                img.color = new Color(img.color.r, img.color.g, img.color.b, currentImageAlpha);
            }

            foreach (Text txt in textToFade)
            {
                txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, currentTextAlpha);
            }
            currentBackgroundAlpha -= (fadeSpeed * baseBackgroundImageAlpha);
            backgroundImage.color = new Color(backgroundImage.color.r, backgroundImage.color.g, backgroundImage.color.b, currentBackgroundAlpha);
            yield return new WaitForSeconds(fadeDelay);
        }
        elementsParent.SetActive(false);
    }

}
