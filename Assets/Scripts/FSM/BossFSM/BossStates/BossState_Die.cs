using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossState_Die : BossState
{

    private bool IsDying = false;

    public override void OnStateEnter(BossFSMBase fsm)
    {
        base.OnStateEnter(fsm);
        Destroy(fsm.Boss.HPSlider.gameObject);
        fsm.Boss.EnemyAnimator.SetBool("IsDie", true);
        fsm.Boss.Audio.clip = fsm.Boss.Die;
        fsm.Boss.Audio.Play();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if(fsm.Boss.EnemyAnimatorStateInfo.normalizedTime <= 0.5f)
            IsDying = true;
        if(fsm.Boss.EnemyAnimatorStateInfo.normalizedTime >= 1f && IsDying)
        {
            GameManager.Instance.BossKills++;
            Instantiate(fsm.Boss.TransDoor,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }


    public override void Change()
    {
        
    }
}
