using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubberbandingGrabInteractable : MonoBehaviour
{
    private Vector3 initialPosition;
    private bool objectReleased;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        objectReleased = false;
    }

    public void onGrab()
    {
        objectReleased = false;
    }

    public void onRelease()
    {
        objectReleased = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (objectReleased)
        {
            
            if (Vector3.Distance(transform.position, initialPosition) > .001f)
            {
                transform.position = Vector3.MoveTowards(transform.position, initialPosition, speed * Time.deltaTime);
            } 
        }
    }
}
