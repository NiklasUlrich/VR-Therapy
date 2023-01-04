using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainEvent : ExperienceEvent
{
    public bool WaitForPreviousEventToFinishFirst;
    public ExperienceEvent PreviousEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PreviousEvent.Started())
        {
            if(!WaitForPreviousEventToFinishFirst || PreviousEvent.Finished())
            {
                StartEvent();
            }
        }
    }
}
