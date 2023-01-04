using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnParticleCollision: MonoBehaviour
{
    public AK.Wwise.Event RainDropWwiseEvent;

    public GameObject ChimeSoundPlayer;

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
        part = other.GetComponent<ParticleSystem>();

        int numCollisionEvents = part.GetCollisionEvents(gameObject, collisionEvents);

        Debug.Log("DEBUG: getting " + numCollisionEvents + " collision events");

        int i = 0;

        while (i < numCollisionEvents)
        {
            Vector3 pos = collisionEvents[i].intersection;
            ChimeSoundPlayer.transform.position = pos;

            Debug.Log("DEBUG: Playing sound at " + ChimeSoundPlayer.transform.position);

            RainDropWwiseEvent.Post(ChimeSoundPlayer);
            i++;
        }
    }
}