using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainEvent : ExperienceEvent
{
    public bool WaitForPreviousEventToFinishFirst;
    public ExperienceEvent PreviousEvent;
    private bool started = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!started && PreviousEvent.Started())
        {
            if(!WaitForPreviousEventToFinishFirst || PreviousEvent.Finished())
            {
                StartEvent();
                started = true;
            }
        }
    }
}
