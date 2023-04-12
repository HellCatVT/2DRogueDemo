using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossState_Run : BossState
{

    private float RunTimePass = 0;

    public override void OnStateEnter(BossFSMBase fsm)
    {
        base.OnStateEnter(fsm);
        fsm.Boss.RandomMoveDirection();
        RunTimePass = 0;
    }

    public override void OnFixedUpdate()
    {
        if (RunTimePass > 1)
        {
            base.OnUpdate();
        }
        RunTimePass += Time.deltaTime;
        
        fsm.transform.Translate(fsm.Boss.MoveDirection.x * fsm.Boss.MoveSpeed * Time.fixedDeltaTime, fsm.Boss.MoveDirection.y * fsm.Boss.MoveSpeed * Time.fixedDeltaTime, 0);
    }

    public override void Change()
    {
        if (fsm.IsDie)
            fsm.ChangeState(fsm.Die);
        if (fsm.IsLaunchRockets)
            fsm.ChangeState(fsm.LaunchRockets);
        else
        {
            if(fsm.IsFlaming)
                fsm.ChangeState(fsm.Flaming);
            else
            {
                if(fsm.IsFiring)
                    fsm.ChangeState(fsm.Firing);
            }
        }
    }
}
