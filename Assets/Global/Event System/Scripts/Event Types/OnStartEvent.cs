using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStartEvent : ExperienceEvent
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I am a start action and i am being called on scene start"!);
        StartEvent();
    }
}
