using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostSoundEventAction : EventAction
{
    //Commented 'til our own integration stands
    //public AK.Wwise.Event wwiseEvent;

    public GameObject playingObject;

    public override void StartAction()
    {
        //wwiseEvent.Post(playingObject);
        base.StartAction();
    }
}
