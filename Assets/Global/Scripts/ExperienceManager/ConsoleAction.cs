using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleAction : EventAction
{
    public string text;

    public override bool Finished()
    {
        return finished;
    }

    public override void StartAction()
    {
        Debug.Log("[Debug] " + text);
        finished = true;
    }
}
