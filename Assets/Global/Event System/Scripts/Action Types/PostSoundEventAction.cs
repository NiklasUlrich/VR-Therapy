using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostSoundEventAction : EventAction
{
    public AudioSource audioClip;

    public override void StartAction()
    {
        audioClip.Play();
        base.StartAction();
    }
}
