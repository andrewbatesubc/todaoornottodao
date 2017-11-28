using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public Text debugText;
    public GameObject fadeBackground;
    public Image fadeImage;
    public float heightFromGround = 5.0f;
    public float fadeSpeed = 0.1f;
    public float fadeDelay = 0.2f;

    private bool canMove = true;

    void Awake() {
        fadeImage = fadeBackground.GetComponent<Image>();
    }

    public void HandleClick(BaseEventData data)
    {
        if (canMove) {
            PointerEventData newData = (PointerEventData)data;
            if (newData.pointerCurrentRaycast.gameObject.name != "Terrain") {
                return;
            }
            StartCoroutine(FadeAndMove(newData.pointerCurrentRaycast.worldPosition));
        }
    }

    public void UpdatePosition(Vector3 newPosition) {
        newPosition.y += heightFromGround;
        transform.position = newPosition;
    }

    IEnumerator FadeAndMove(Vector3 newPosition)
    {
        canMove = false;
        EnableFadeObject();
        yield return StartCoroutine(FadeToBlack());
        UpdatePosition(newPosition);
        yield return StartCoroutine(FadeFromBlack());
        fadeBackground.SetActive(false);
        canMove = true;
        yield return null;
    }

    IEnumerator FadeToBlack() {
        Color col = fadeImage.color;
        while (fadeImage.color.a < 1.0f)
        {
            fadeImage.color = new Color(col.r, col.g, col.b, col.a + fadeSpeed);
            col = fadeImage.color;
            yield return new WaitForSeconds(fadeDelay);
        }
    }

    IEnumerator FadeFromBlack()
    {
        Color col = fadeImage.color;
        while (fadeImage.color.a >= 0.0f)
        {
            fadeImage.color = new Color(col.r, col.g, col.b, col.a - fadeSpeed);
            col = fadeImage.color;
            yield return new WaitForSeconds(fadeDelay);
        }
    }

    void EnableFadeObject() {
        Color oldColor = fadeImage.color;
        fadeImage.color = new Color(oldColor.r, oldColor.g, oldColor.b, 0.0f);
        fadeBackground.SetActive(true);
    }
}
