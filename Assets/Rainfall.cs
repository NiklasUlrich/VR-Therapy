using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rainfall : MonoBehaviour
{
    public ParticleSystem part;

    public AK.Wwise.Event ChimeWwiseEvent;

    // Start is called before the first frame update
    void Start()
    {
        part = GetComponent<ParticleSystem>();
        Debug.Log("DEBUG: starting rainfall");
        ChimeWwiseEvent.Post(gameObject );
    }

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("DEBUG: Raindrop hit ground");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
