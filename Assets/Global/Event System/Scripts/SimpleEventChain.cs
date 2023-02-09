using System.Collections.Generic;
using UnityEngine;

public class SimpleEventChain : MonoBehaviour
{
    [Tooltip("List of events which will be triggered in this order. This overrides the PreviousEvent fields of those events")]
    public List<ChainEvent> events;
    public float initialDelayInSeconds;

    // Start is called before the first frame update
    void Start()
    {
        FirstChainEvent startEvent = gameObject.AddComponent(typeof(FirstChainEvent)) as FirstChainEvent;
        startEvent.delayInSeconds = initialDelayInSeconds;
        OverRideChainOrder(startEvent);
        startEvent.BeginChain();
    }

    //overrides the previous event fields of the chainevents according to the list
    private void OverRideChainOrder(FirstChainEvent firstEvent)
    {
        events[0].PreviousEvent = firstEvent;

        for(int i = 1; i < events.Count; i++)
        {
            events[i].PreviousEvent = events[i - 1];
        }
    }

    private class FirstChainEvent: ExperienceEvent
    {
        public void BeginChain()
        {
            StartEvent();
        }

    }

}

