using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossState_Flaming : BossState
{

    public override void OnStateEnter(BossFSMBase fsm)
    {
        base.OnStateEnter(fsm);
        fsm.Boss.EnemyAnimator.SetBool("IsFlaming",true);
        fsm.Boss.Audio.clip = fsm.Boss.Flaming;
        fsm.Boss.Audio.Play();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if(fsm.Boss.EnemyAnimatorStateInfo.IsName("Boss_Flaming Animation"))
        {
            if (fsm.Boss.EnemyAnimatorStateInfo.normalizedTime >= 0.25f)
                fsm.Boss.FlamingArea.GetComponent<Flaming>().enabled = true;
            if (fsm.Boss.EnemyAnimatorStateInfo.normalizedTime >= 0.75f)
            {
                fsm.Boss.ResetFlamingTimePass();
                fsm.Boss.FlamingArea.GetComponent<Flaming>().enabled = false;
                fsm.IsFlaming = false;
            }
        }
        
    }

    public override void OnFixedUpdate()
    {
        base.OnUpdate();
        fsm.transform.Translate(fsm.Boss.AimDirection.normalized.x * (fsm.Boss.MoveSpeed) * Time.fixedDeltaTime, fsm.Boss.AimDirection.normalized.y * (fsm.Boss.MoveSpeed) * Time.fixedDeltaTime, 0);
    }

    public override void Change()
    {
        if (fsm.IsDie)
            fsm.ChangeState(fsm.Die);
        if (!fsm.IsFlaming)
        {
            fsm.Boss.RandomMoveDirection();
            fsm.Boss.EnemyAnimator.SetBool("IsFlaming", false);
            fsm.ChangeState(fsm.Run);
        }
    }
}
