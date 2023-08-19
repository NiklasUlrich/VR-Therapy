using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFirstStartEvent : ExperienceEvent
{
    public string eventTag;
    // Start is called before the first frame update
    void Start()
    {
        if (!Player.player.AlreadyExecuted(eventTag))
        {
            Player.player.AddExecutedTag(eventTag);
            StartEvent();
        }
        
    }
}
