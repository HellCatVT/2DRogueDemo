using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class FSMBase : MonoBehaviour
{
    [HideInInspector]
    public State Run;
    [HideInInspector]
    public State Idle;
    [HideInInspector]
    public State Firing;
    [HideInInspector]
    public State Die;

    public Enemy Enemy;

    public bool IsPlayerExist = true;

    public bool IsAttaking = false;

    public bool IsDead = false;

    public State CurrentState = null;

    public AudioSource Audio;

    public AudioClip Dead;

    /// <summary>
    /// 切换状态
    /// </summary>
    /// <param name="state">目标状态</param>
    public virtual void ChangeState(State state)
    {
        if(CurrentState != null)
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
