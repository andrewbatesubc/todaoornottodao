using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    private static PlayerMovement instance;
    public static PlayerMovement GetInstance()
    {
        if (instance == null)
        {
            instance = GameObject.FindObjectOfType<PlayerMovement>();
        }
        return instance;
    }

    public Text debugText;
    public float heightFromGround = 5.0f;
    public Fade fade;

    private bool canMove = true;


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

   
    public IEnumerator FadeAndMove(Vector3 newPosition, GameObject[] objectsToDisable = null)
    {
        canMove = false;
        yield return StartCoroutine(fade.FadeToBlack());
        UpdatePosition(newPosition);
        if (objectsToDisable != null)
        {
            foreach (GameObject go in objectsToDisable)
            {
                go.SetActive(false);
            }
        }
        yield return StartCoroutine(fade.FadeFromBlack());
        canMove = true;
        yield return null;
    }

    public void UpdatePosition(Vector3 newPosition)
    {
        newPosition.y += heightFromGround;
        transform.position = newPosition;
    }

    public void SetCanMove(bool canMove)
    {
        this.canMove = canMove;
    }
}
