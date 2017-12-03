using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDistanceHelper : MonoBehaviour {

    public CanvasChildFade canvasChildFade;
    public GameObject player;
    public float distanceToEnable = 15.0f;

    float distance = 0.0f;
    private void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance <= distanceToEnable)
        {
            canvasChildFade.gameObject.SetActive(false);
            canvasChildFade.gameObject.SetActive(true);
            canvasChildFade.FadeInChildren();
            Destroy(this.gameObject);
        }

    }
}
