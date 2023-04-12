using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossState_Idle : BossState
{
    public override void Change()
    {
        if (fsm.IsPlayerApproch)
        {
            fsm.Boss.HPSlider = Instantiate(fsm.Boss.BossHPBarOBJ,GameObject.Find("Canvas").transform).GetComponent<Slider>(); 
            fsm.ChangeState(fsm.Run);
            fsm.Boss.EnemyAnimator.SetBool("IsPlayerInRoom",true);
        }
            

    }
}
