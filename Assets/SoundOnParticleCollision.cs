using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnParticleCollision: MonoBehaviour
{
    public AK.Wwise.Event collisionWwiseEvent;

    public GameObject soundPlayer;

    public string particleSystemTag;

    ParticleSystem part;

    List<ParticleCollisionEvent> collisionEvents;

    // Start is called before the first frame update
    void Start()
    {
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        if(particleSystemTag == null || other.CompareTag(particleSystemTag))
        {
            part = other.GetComponent<ParticleSystem>();

            int numCollisionEvents = part.GetCollisionEvents(gameObject, collisionEvents);

            Debug.Log("DEBUG: getting " + numCollisionEvents + " collision events");

            int i = 0;

            while (i < numCollisionEvents)
            {
                Vector3 pos = collisionEvents[i].intersection;
                soundPlayer.transform.position = pos;

                Debug.Log("DEBUG: Playing sound at " + soundPlayer.transform.position);

                collisionWwiseEvent.Post(soundPlayer);
                i++;
            }
        }
    }
}