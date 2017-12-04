using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueEventHandler : MonoBehaviour {
    public GameObject canvas;
    public GameObject newCanvas;
    public GameObject destination;
    public PlayerMovement movement;
    private bool isSelected = false;
    public Fade fader;

    public void HandleAnswer()
    {
        if (!isSelected)
        {
            StartCoroutine(CrossPlague());
        }
    }

    IEnumerator CrossPlague()
    {
        isSelected = true;
        yield return StartCoroutine(movement.FadeAndMove(destination.transform.position, new GameObject[] { canvas }));
        newCanvas.SetActive(true);
        isSelected = false;
    }
}
