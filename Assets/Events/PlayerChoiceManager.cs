using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChoiceManager : MonoBehaviour {

    private static PlayerChoiceManager instance;
    public static PlayerChoiceManager GetInstance() {
        if (instance == null) {
            instance = GameObject.FindObjectOfType<PlayerChoiceManager>();
            instance.InitDictionary();
        }
        return instance;
    }

    private Dictionary<string, bool> decisionDictionary;

    [SerializeField]
    private float zuangziPoints = 0;
    [SerializeField]
    private float laoziPoints = 0;
    [SerializeField]
    private float fangshiPoints = 0;

    private int eventIndex = 0;

    public void InitDictionary() {
        decisionDictionary = new Dictionary<string, bool>();
    }

    public bool IsDecisionSatisfied(string decision) {
        if (decisionDictionary.ContainsKey(decision) && decisionDictionary[decision]) {
            return true;
        }
        return false;
    }

    public void SetDecision(string decision) {
        decisionDictionary[decision] = true;
    }

    public void AddZuangziPoints(float value)
    {
        zuangziPoints += value;
        Debug.Log("New Zuangzi points: " + zuangziPoints);
    }

    public void AddLaoziPoints(float value)
    {
        laoziPoints += value;
        Debug.Log("New Laozi points: " + laoziPoints);
    }

    public void AddFangshiPoints(float value)
    {
        fangshiPoints += value;
        Debug.Log("New Fangshi points: " + fangshiPoints);
    }

    public float GetLaoziPoints() {
        return laoziPoints;
    }

    public float GetZuangziPoints()
    {
        return zuangziPoints;
    }

    public float GetFangshiPoints()
    {
        return fangshiPoints;
    }

}
