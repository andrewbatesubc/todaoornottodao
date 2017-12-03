using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventHandlerParent : MonoBehaviour{

    public abstract void HandleNextStep(string message, int subEventIndex);
}
