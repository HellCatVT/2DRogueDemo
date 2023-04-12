using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BossState_Firing : BossState
{

    public int BulletCount = 0;

    public override void OnStateEnter(BossFSMBase fsm)
    {
        base.OnStateEnter(fsm);
        fsm.Boss.EnemyAnimator.SetBool("IsFiring",true);
    }

    public void BulletGenerate()
    {
        fsm.Boss.Audio.clip = fsm.Boss.Firing;
        fsm.Boss.Audio.Play();
        GameObject bullet =  Instantiate(fsm.Boss.BulletOBJ, fsm.Boss.FirePointTF.position, fsm.Boss.AimRotation);
        bullet.GetComponent<BulletEnemy>().ATK = fsm.Boss.ATK;
        bullet.GetComponent<BulletEnemy>().BulletSpeed = fsm.Boss.BulletSpeed;
        BulletCount++;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (BulletCount == 0 && fsm.Boss.EnemyAnimatorStateInfo.normalizedTime < 0.25f)
            BulletGenerate();
        if (BulletCount == 1 && fsm.Boss.EnemyAnimatorStateInfo.normalizedTime >= 0.25f)
            BulletGenerate();
        if (BulletCount == 2 && fsm.Boss.EnemyAnimatorStateInfo.normalizedTime >= 0.5f)
            BulletGenerate();
        if (BulletCount == 3 && fsm.Boss.EnemyAnimatorStateInfo.normalizedTime >= 0.75f)
            BulletGenerate();
        if (BulletCount == 4 && fsm.Boss.EnemyAnimatorStateInfo.normalizedTime >= 1f)
        {
            fsm.Boss.ResetTimePass();
            fsm.IsFiring = false;
        }
    }


    public override void Change()
    {
        if (fsm.IsDie)
            fsm.ChangeState(fsm.Die);
        if (!fsm.IsFiring)
        {

            fsm.Boss.RandomMoveDirection();
            fsm.Boss.EnemyAnimator.SetBool("IsFiring", false);
            BulletCount = 0;
            fsm.ChangeState(fsm.Run);
        }
    }

}
