using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceEvent : MonoBehaviour
{
    //List of the actions the event triggers
    [SerializeField, SerializeReference]
    [Tooltip("The actions whoch will be triggered when the event triggers.")]
    public List<EventAction> eventActions;

    [Tooltip("Delay after which the event will trigger.")]
    public float delayInSeconds;

    private bool started = false; //true once all actions are started
    private bool triggered = false; //true once InitializeEvent() was called

    protected void StartEvent()
    {
        StartCoroutine(InitializeEvent());
    }

    //executes all of the events actions, then sets finished to true
    private IEnumerator InitializeEvent()
    {
        triggered = true;
        yield return new WaitForSeconds(delayInSeconds);

        if(eventActions != null ){
            foreach (EventAction eventAction in eventActions)
            {
                eventAction.StartAction();
            }
        }
        started = true;
    }

    //returns true if all contained actions have been fully executed
    public bool Finished()
    {
        if (eventActions != null)
        {
            foreach(EventAction eventAction in eventActions)
            {
                if (!eventAction.Finished()) return false;
            }
            return started; //returns started cause the event should only be considered finished after being started
        }
        return started; //returns started cause the event should only be considered finished after being started
    }
    
    public bool Started()
    {
        return started;
    }

    public bool Triggered()
    {
        return triggered;
    }
}
