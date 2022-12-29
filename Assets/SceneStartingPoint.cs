using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStartingPoint : MonoBehaviour
{
    public string playerObjectName; // Name of the player object

    void Awake()
    {
        // Find the player object
        GameObject player = GameObject.Find(playerObjectName);
        if (player == null)
        {
            Debug.LogError("Player object not found");
            return;
        }

        // Set the player's position to the position of the proxy object
        player.transform.SetPositionAndRotation(transform.position, transform.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
