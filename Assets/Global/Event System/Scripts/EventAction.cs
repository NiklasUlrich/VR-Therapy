using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventAction: MonoBehaviour
{
    protected bool finished = false;
    public virtual bool Finished()
    {
        return finished;
    }
    public virtual void StartAction()
    {
        throw new System.NotImplementedException();
    }
}
