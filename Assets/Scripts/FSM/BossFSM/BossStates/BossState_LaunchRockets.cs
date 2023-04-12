using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossState_LaunchRockets : BossState
{
    private int RocketCount = 0;

    public override void OnStateEnter(BossFSMBase fsm)
    {
        base.OnStateEnter(fsm);
        fsm.Boss.EnemyAnimator.SetBool("IsRocket",true);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (RocketCount == 0 && fsm.Boss.EnemyAnimatorStateInfo.normalizedTime < 0.25f)
            GenerateRocket();
        else if(RocketCount == 1 && fsm.Boss.EnemyAnimatorStateInfo.normalizedTime >= 0.75f)
            GenerateRocket();
        if (RocketCount==2 && fsm.Boss.EnemyAnimatorStateInfo.normalizedTime >= 1f)
        {
            RocketCount = 0;
            fsm.Boss.ResetRocketTimePass();
            fsm.IsLaunchRockets = false;
        }
    }

    public void GenerateRocket()
    {
        fsm.Boss.Audio.clip = fsm.Boss.LaunchRocket;
        fsm.Boss.Audio.Play();
        GameObject Rocket = Instantiate(fsm.Boss.RocketOBJ,fsm.Boss.RocketFirePintTF.position,fsm.Boss.AimRotation);
        Rocket.GetComponent<RocketBullet>().ATK = fsm.Boss.RocketATK;
        Rocket.GetComponent<RocketBullet>().BulletSpeed = fsm.Boss.RocketSpeed;
        RocketCount++;
    }

    public override void Change()
    {
        if (fsm.IsDie)
            fsm.ChangeState(fsm.Die);
        if (!fsm.IsLaunchRockets)
        {
            fsm.Boss.RandomMoveDirection();
            fsm.Boss.EnemyAnimator.SetBool("IsRocket",false);
            fsm.ChangeState(fsm.Run);
        }
    }

}
