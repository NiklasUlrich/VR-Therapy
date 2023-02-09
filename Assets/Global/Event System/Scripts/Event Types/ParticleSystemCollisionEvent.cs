using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemCollisionEvent: ExperienceEvent
{
    //Commented 'til our own integration stands

    public GameObject collisionMarker;

    public string particleSystemTag;

    ParticleSystem part;

    List<ParticleCollisionEvent> collisionEvents;

    // Start is called before the first frame update
    void Start()
    {
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    private void OnParticleCollision(GameObject other)
    {
        if(particleSystemTag == null || particleSystemTag == null || other.CompareTag(particleSystemTag))
        {
            part = other.GetComponent<ParticleSystem>();

            int numCollisionEvents = part.GetCollisionEvents(gameObject, collisionEvents);

            //Debug.Log("DEBUG: getting " + numCollisionEvents + " collision events");

            int i = 0;

            while (i < numCollisionEvents)
            {
                Vector3 pos = collisionEvents[i].intersection;
                if (collisionMarker != null)
                {
                    collisionMarker.transform.position = pos;
                }

                i++;
            }

            StartEvent();
        }
    }
}