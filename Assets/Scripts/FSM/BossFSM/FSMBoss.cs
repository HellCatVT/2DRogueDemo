using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMBoss : BossFSMBase
{

    private void Start()
    {
        Idle = gameObject.AddComponent<BossState_Idle>();
        Run = gameObject.AddComponent<BossState_Run>();
        Firing = gameObject.AddComponent<BossState_Firing>();
        LaunchRockets = gameObject.AddComponent<BossState_LaunchRockets>();
        Flaming = gameObject.AddComponent<BossState_Flaming>();
        Die = gameObject.AddComponent<BossState_Die>();
        ChangeState(Idle);
    }

    private void Update()
    {

        ConditionChange();
        if (IsPlayerApproch)
        {
            Boss.TimePass -= Time.deltaTime;
            Boss.FlamingTimePass -= Time.deltaTime;
            Boss.RocketTimePass -= Time.deltaTime;
        }

        CurrentState.OnUpdate();
    }

    private void FixedUpdate()
    {
        CurrentState.OnFixedUpdate();
    }

    public override void ConditionChange()
    {
        if (Boss.HP <= 0)
            IsDie = true;
        if (Boss.RocketTimePass <= 0)
            IsLaunchRockets = true;
        if (Boss.FlamingTimePass <= 0)
            IsFlaming = true;
        if (Boss.TimePass <=0)
            IsFiring = true;
    }


}
