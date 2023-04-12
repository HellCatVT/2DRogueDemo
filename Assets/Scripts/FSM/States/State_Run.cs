using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class State_Run : State
{

    public override void OnStateEnter(FSMBase fsm)
    {
        fsm.Enemy.RandomMoveDirection();
        fsm.Enemy.EnemyAnimator.SetBool("IsAttacking", false);
        base.OnStateEnter(fsm);
    }

    public override void OnFixedUpdate()
    {
        base.OnUpdate();
        if (!fsm.Enemy.isHurt)
        {
            fsm.transform.Translate(fsm.Enemy.MoveDirection.x * fsm.Enemy.MoveSpeed * Time.fixedDeltaTime, fsm.Enemy.MoveDirection.y * fsm.Enemy.MoveSpeed * Time.fixedDeltaTime, 0);
        }
    }


    public override void Change()
    {
        if (!fsm.IsPlayerExist)
            fsm.ChangeState(fsm.Idle);
        if (fsm.IsDead)
            fsm.ChangeState(fsm.Die);
        if (fsm.IsAttaking)
            fsm.ChangeState(fsm.Firing);
    }
}

