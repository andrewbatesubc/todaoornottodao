using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestChangeColor : MonoBehaviour {

    public void EnterHandler()
    {
        Text text = GetComponent<Text>();
        text.color = Color.red;
    }

    public void ExitHandler()
    {
        Text text = GetComponent<Text>();
        text.color = Color.white;
    }
}
