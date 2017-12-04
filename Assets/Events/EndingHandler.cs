using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingHandler : MonoBehaviour {

    public Text laoziText;
    public Text zuangziText;
    public Text fangshiText;

    void Update () {
        laoziText.text = "Total Laozi points: " + PlayerChoiceManager.GetInstance().GetLaoziPoints();
        zuangziText.text = "Total Zuangzi points: " + PlayerChoiceManager.GetInstance().GetZuangziPoints();
        fangshiText.text = "Total Fangshi points: " + PlayerChoiceManager.GetInstance().GetFangshiPoints();
    }
}
