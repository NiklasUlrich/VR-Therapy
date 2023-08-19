using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player player;
    private List<string> alreadyExecutedTags;

    // Start is called before the first frame update
    void Start()
    {
        if (!player)
        {
            player = this;
            alreadyExecutedTags = new List<string>();
        }
        else
        {
            Destroy(this);
        }
    }

    public void AddExecutedTag(string tag)
    {
        alreadyExecutedTags.Add(tag);
    }

    public bool AlreadyExecuted(string tag)
    {
        return alreadyExecutedTags.Contains(tag);
    }
}
