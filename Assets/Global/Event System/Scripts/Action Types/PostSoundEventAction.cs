using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostSoundEventAction : EventAction
{
    public AK.Wwise.Event wwiseEvent;

    public GameObject playingObject;

    public override void StartAction()
    {
        wwiseEvent.Post(playingObject);
        base.StartAction();
    }
}
