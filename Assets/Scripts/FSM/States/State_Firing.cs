using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Firing : State
{

    public float T;

    private bool IsBulletFirst = false;

    private bool IsBulletSecond = false;

    public override void OnStateEnter(FSMBase fsm)
    {
        T = fsm.Enemy.EnemyAnimatorStateInfo.normalizedTime;
        base.OnStateEnter(fsm);
        fsm.Enemy.EnemyAnimator.SetBool("IsAttacking",true);
    }

    public override void OnUpdate()
    {
        T = fsm.Enemy.EnemyAnimatorStateInfo.normalizedTime;
        base.OnUpdate();
        Attack();
    }




    private void Attack()
    {
        if (fsm.Enemy.TimePass <= 0)
        {
            if (!IsBulletFirst )
            {
                IsBulletFirst = true;
                GenerateBullet();
            }
            if(!IsBulletSecond && fsm.Enemy.EnemyAnimatorStateInfo.normalizedTime> 0.5f)
            {
                IsBulletSecond = true;
                GenerateBullet();
            }
            if (fsm.Enemy.EnemyAnimatorStateInfo.normalizedTime >= 1)
            {
                fsm.Enemy.TimePass = fsm.Enemy.ATKRate;
                IsBulletFirst = false;
                IsBulletSecond= false;
            }
                
        }
    }

    /// <summary>
    /// ×Óµ¯Éú³É
    /// </summary>
    private void GenerateBullet()
    {
        GameObject bullet = Instantiate(fsm.Enemy.BulletOBJ, fsm.Enemy.FirePointTF.position, fsm.Enemy.AimRotation) as GameObject;
        bullet.GetComponent<BulletEnemy>().BulletSpeed = fsm.Enemy.BulletSpeed;
        bullet.GetComponent<BulletEnemy>().ATK = fsm.Enemy.ATK;
    }

    public override void Change()
    {
        if (fsm.IsDead)
            fsm.ChangeState(fsm.Die);
        if (!fsm.IsPlayerExist)
            fsm.ChangeState(fsm.Idle);
        if (!fsm.IsAttaking)
            fsm.ChangeState(fsm.Run);
    }
}
