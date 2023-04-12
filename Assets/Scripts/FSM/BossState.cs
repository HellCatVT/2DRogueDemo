using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossState : MonoBehaviour
{
    protected BossFSMBase fsm;

    public virtual void OnUpdate()
    {
        Change();
    }

    public virtual void OnFixedUpdate() { }

    public virtual void OnStateEnter(BossFSMBase fsm)
    {

        this.fsm = fsm;

    }

    public virtual void OnStateExit() { }

    public abstract void Change();
}
