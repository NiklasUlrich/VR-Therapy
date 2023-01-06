using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventAction: MonoBehaviour
{
    protected bool finished = false;

    public virtual bool Finished()
    {
        return finished;
    }
    public virtual void StartAction()
    {
        finished = true;
    }
}
