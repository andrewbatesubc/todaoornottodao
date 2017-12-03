using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookEventHandler : MonoBehaviour {

    public GameObject offerHelpCanvas;
    public GameObject helpRejectedCanvas;
    public GameObject carveWoodCanvas;
    public GameObject approachCanvas;
    public GameObject firstComplicatedCanvas;
    public GameObject secondComplicatedCanvas;
    public GameObject thirdComplicatedCanvas;
    public GameObject fourthComplicatedCanvas;
    public GameObject fifthComplicatedCanvas;
    public GameObject keepOrGiveMeatCanvas;
    public GameObject goodbyeAfterHelpCanvas;
    public Text goodbyeText;
    public GameObject newTreePath;
    public PlayerChoiceManager manager;
    public Fade fader;
    public GameObject cookObjects;
    public GameObject blockerObjects;
    public GameObject cowObject;
    public GameObject meatObject;

    public AudioSource cowSource;
    public AudioClip meatSlap;

    bool isSelected = false;

    [TextArea]
    public string MeatKeptText;

    [TextArea]
    public string MeatGivenText;

    public void HandleOfferHelpCook()
    {
        if (!isSelected)
        {
            StartCoroutine(RoutineHelper(new GameObject[] { offerHelpCanvas }, new GameObject[] { carveWoodCanvas }));
        }
    }

    public void HandleDontHelpCook()
    {
        if (!isSelected)
        {
            StartCoroutine(RoutineHelper(new GameObject[] { offerHelpCanvas }, new GameObject[] { helpRejectedCanvas }));
        }
    }

    public void HandleAllFinishedReject() {

        if (!isSelected)
        {
            StartCoroutine(RoutineHelper(new GameObject[] { helpRejectedCanvas, newTreePath, blockerObjects}, new GameObject[] { }));
        }
    }

    public void HandleWoodCarving()
    {
        if (!isSelected)
        {
            StartCoroutine(RoutineHelper(new GameObject[] { carveWoodCanvas }, new GameObject[] { approachCanvas }));
        }
    }

    public void HandleApproachOx() {
        if (!isSelected)
        {
            StartCoroutine(RoutineHelper(new GameObject[] { approachCanvas }, new GameObject[] { firstComplicatedCanvas }));
        }
    }

    public void HandleFirstComplicatedPlace() {
        if (!isSelected)
        {
            StartCoroutine(RoutineHelper(new GameObject[] { firstComplicatedCanvas }, new GameObject[] { secondComplicatedCanvas }));
        }
    }

    public void HandleSecondComplicatedPlace()
    {
        if (!isSelected)
        {
            StartCoroutine(RoutineHelper(new GameObject[] { secondComplicatedCanvas }, new GameObject[] { thirdComplicatedCanvas }));
        }
    }
    public void HandleThirdComplicatedPlace()
    {
        if (!isSelected)
        {
            StartCoroutine(RoutineHelper(new GameObject[] { thirdComplicatedCanvas }, new GameObject[] { fourthComplicatedCanvas }));
        }
    }
    public void HandleFourthComplicatedPlace()
    {
        if (!isSelected)
        {
            StartCoroutine(RoutineHelper(new GameObject[] { fourthComplicatedCanvas }, new GameObject[] { fifthComplicatedCanvas }));
        }
    }
    public void HandleFifthComplicatedPlace()
    {
        if (!isSelected)
        {
            StartCoroutine(RoutineHelper(new GameObject[] { fifthComplicatedCanvas, cowObject }, new GameObject[] { keepOrGiveMeatCanvas, meatObject }));
        }
    }

    public void HandleMeatFinishedHarvesting() {
        if (!isSelected)
        {
            if (PlayerChoiceManager.GetInstance().IsDecisionSatisfied("KeepMeat"))
            {
                meatObject.SetActive(false);
                goodbyeText.text = MeatKeptText;
            }
            else
            {
                goodbyeText.text = MeatGivenText;
            }
            StartCoroutine(RoutineHelper(new GameObject[] { keepOrGiveMeatCanvas, blockerObjects }, new GameObject[] { goodbyeAfterHelpCanvas }));
        }
    }

    public void HandleOutro() {
        if (!isSelected)
        {
            StartCoroutine(RoutineHelper(new GameObject[] { goodbyeAfterHelpCanvas, newTreePath}, new GameObject[] {  }));
        }
    }


    IEnumerator RoutineHelper(GameObject[] objectsToDisable, GameObject[] objectsToEnable)
    {
        isSelected = true;
        yield return StartCoroutine(fader.FadeToBlack());
        foreach (GameObject go in objectsToDisable) {
            go.SetActive(false);
        }
        foreach (GameObject go in objectsToEnable)
        {
            go.SetActive(true);
        }
        yield return StartCoroutine(fader.FadeFromBlack());
        isSelected = false;
    }
}
