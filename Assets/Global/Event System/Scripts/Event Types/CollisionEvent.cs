using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEvent : ExperienceEvent
{
    public string otherColliderTag;

    public void OnTriggerEnter(Collider other)
    {
        if(otherColliderTag == null || other.tag == otherColliderTag)
        {
            StartEvent();
        }
    }
}
