using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverSounds : MonoBehaviour {

    AudioSource[] riverSoundSources;
    public float firstSoundDelay = 0.0f;
    public float secondSoundDelay = 5.0f;
    public float thirdSoundDelay = 5.0f;
    public float fourthSoundDelay = 5.0f;

    void Awake () {
        riverSoundSources = GetComponentsInChildren<AudioSource>();
        StartCoroutine(triggerSound(firstSoundDelay, 0));
        StartCoroutine(triggerSound(secondSoundDelay, 1));
        StartCoroutine(triggerSound(thirdSoundDelay, 2));
        StartCoroutine(triggerSound(fourthSoundDelay, 3));
    }

    IEnumerator triggerSound (float delay, int index) {
	    yield return new WaitForSeconds(delay);
        riverSoundSources[index].Play();
	}
}
