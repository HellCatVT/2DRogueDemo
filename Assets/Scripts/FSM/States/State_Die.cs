using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class State_Die : State
{
    public bool IsDying = false;


    public override void OnStateEnter(FSMBase fsm)
    {
        base.OnStateEnter(fsm);
        fsm.Enemy.EnemyAnimator.SetBool("IsDead",true);
        fsm.Audio.clip = fsm.Dead;
        fsm.Audio.Play();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        Die();
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }

    private void Die()
    {
        if(fsm.Enemy.EnemyAnimatorStateInfo.normalizedTime < 0.75)
            IsDying = true;
        if (fsm.Enemy.EnemyAnimatorStateInfo.normalizedTime >= 1 && IsDying)
        {
            PlayerController.Instance.GainEXP(fsm.Enemy.EXP);
            fsm.Enemy.EnemyDeadCount?.Invoke();
            GameManager.Instance.kills++;
            Destroy(fsm.gameObject);
        }
            
    }

    public override void Change()
    {
    }
}
