using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceEvent : MonoBehaviour
{
    //List of the actions the event triggers
    [SerializeField, SerializeReference]
    public List<EventAction> eventActions;

    //the delay with which the eventactions will be started
    public float delayInSeconds;

   
    private bool started = false;

    protected void StartEvent()
    {
        StartCoroutine(InitializeEvent());
    }

    //executes all of the events actions, then sets finished to true
    private IEnumerator InitializeEvent()
    {
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
}
