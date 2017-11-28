using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TestDeleteEnterTerrain : MonoBehaviour {

    public Text debugText;

    public PlayerMovement playerMovement;

    public void HandleEnter(BaseEventData data) {
        PointerEventData newData = (PointerEventData)data;
        debugText.text = "Entered!";
    }

    public void HandleExit(BaseEventData data)
    {
        debugText.text = "Exited!";
    }

    public void HandleClick(BaseEventData data)
    {
        PointerEventData newData = (PointerEventData)data;
        playerMovement.UpdatePosition(newData.pointerCurrentRaycast.worldPosition);
        debugText.text = "Clicked!";
    }
}
