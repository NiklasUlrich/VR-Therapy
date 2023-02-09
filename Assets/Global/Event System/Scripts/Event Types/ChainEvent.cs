using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainEvent : ExperienceEvent
{
    [Tooltip("The event after which this event will trigger")]
    public ExperienceEvent PreviousEvent;
    [Tooltip("If checked, the event will only trigger after all actions of the previous event have been finished")]
    public bool WaitForPreviousEventToFinishFirst;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!Triggered() && PreviousEvent.Started())
        {
            if(!WaitForPreviousEventToFinishFirst || PreviousEvent.Finished())
            {
                StartEvent();
            }
        }
    }
}
