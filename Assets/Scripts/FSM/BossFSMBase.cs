using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossFSMBase : MonoBehaviour
{
    [HideInInspector]
    public BossState Run;
    [HideInInspector]
    public BossState Idle;
    [HideInInspector]
    public BossState Firing;
    [HideInInspector]
    public BossState Flaming;
    [HideInInspector]
    public BossState LaunchRockets;
    [HideInInspector]
    public BossState Die;

    public Boss Boss;

    public bool IsFiring;

    public bool IsPlayerApproch;

    public bool IsFlaming;

    public bool IsDie;

    public bool IsLaunchRockets;

    public BossState CurrentState = null;


    /// <summary>
    /// 切换状态
    /// </summary>
    /// <param name="state">目标状态</param>
    public virtual void ChangeState(BossState state)
    {
        if (CurrentState != null)
        {
            CurrentState.OnStateExit();
        }
        state.OnStateEnter(this);
        CurrentState = state;
    }

    /// <summary>
    /// 改变条件
    /// </summary>
    public abstract void ConditionChange();



}
