using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif
using UnityEngine;

public class FSMFlyRobot : FSMBase
{

    private void Start()
    {
        PlayerController.PlayerDie += PlayerDie;
        Run = gameObject.AddComponent<State_Run>();
        Idle = gameObject.AddComponent<State_Idle>();
        Firing = gameObject.AddComponent<State_Firing>();
        Die = gameObject.AddComponent<State_Die>();
        ChangeState(Run);
    }

    private void Update()
    {
        ConditionChange();
        CurrentState.OnUpdate();
    }

    private void FixedUpdate()
    {
        CurrentState.OnFixedUpdate();
    }

    public void PlayerDie()
    {
        IsPlayerExist = false;
    }

    public override void ConditionChange()
    {
        if (Enemy.HP <= 0)
            IsDead = true;

        if (Enemy.TimePass <= 0)
            IsAttaking = true;
        else
            IsAttaking = false;
    }
}
