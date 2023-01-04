using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAction : EventAction
{
    public string objectToTeleportByName;
    public GameObject objectToTeleport;
    
    public Transform destination;

    public override void StartAction()
    {
        if(objectToTeleportByName != null)
        {
            try
            {
                objectToTeleport = GameObject.Find(objectToTeleportByName);
            }
            catch
            {
                Debug.LogError("[Debug]: object to teleport " + objectToTeleportByName + " not found");
            }
        }
        if (objectToTeleport == null)
        {
            Debug.LogError("[Debug]: no object to teleport found");
            return;
        }

        if (destination == null) destination = this.transform;

        // Set the player's position to the position of the proxy object
        objectToTeleport.transform.SetPositionAndRotation(destination.position, destination.rotation);

    }
}
