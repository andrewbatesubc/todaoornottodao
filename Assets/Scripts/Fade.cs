using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Fade : MonoBehaviour {

    public Text debugText;
    public GameObject fadeBackground;
    private Image fadeImage;
    public float fadeSpeed = 0.1f;
    public float fadeDelay = 0.02f;

    private bool canMove = true;

    void Awake()
    {
        fadeImage = fadeBackground.GetComponent<Image>();
    }

    public IEnumerator FadeToBlack()
    {
        EnableFadeObject();
        Color col = fadeImage.color;
        while (fadeImage.color.a < 1.0f)
        {
            fadeImage.color = new Color(col.r, col.g, col.b, col.a + fadeSpeed);
            col = fadeImage.color;
            yield return new WaitForSeconds(fadeDelay);
        }
    }

    public IEnumerator FadeFromBlack()
    {
        Color col = fadeImage.color;
        while (fadeImage.color.a >= 0.0f)
        {
            fadeImage.color = new Color(col.r, col.g, col.b, col.a - fadeSpeed);
            col = fadeImage.color;
            yield return new WaitForSeconds(fadeDelay);
        }
        fadeBackground.SetActive(false);
    }

    void EnableFadeObject()
    {
        Color oldColor = fadeImage.color;
        fadeImage.color = new Color(oldColor.r, oldColor.g, oldColor.b, 0.0f);
        fadeBackground.SetActive(true);
    }
}
