using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected FSMBase fsm;

    public virtual void OnUpdate() 
    {
        Change();
    }

    public virtual void OnFixedUpdate() { }

    public virtual void OnStateEnter(FSMBase fsm) 
    {

        this.fsm = fsm;

    }

    public virtual void OnStateExit() { }

    public abstract void Change();

}
