using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEvent : ExperienceEvent
{
    [Tooltip("The tag of the object that will trigger the collision event. Leave empty to trigger on all collisions")]
    public string otherColliderTag;

    public void OnTriggerEnter(Collider other)
    {
        if(otherColliderTag == null || other.CompareTag(otherColliderTag))
        {
            StartEvent();
        }
    }
}
