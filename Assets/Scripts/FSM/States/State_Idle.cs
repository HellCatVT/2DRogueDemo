using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class State_Idle : State
{
    public override void OnStateEnter(FSMBase fsm)
    {
        base.OnStateEnter(fsm);
        fsm.Enemy.EnemyAnimator.SetBool("IsPlayerExist",false);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        Change();
    }

    public override void Change()
    {
    }


}
