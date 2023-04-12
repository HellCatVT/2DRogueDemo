using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProtector : Enemy
{
    private float HurtTimePass = 0;
    private void Start()
    {
        HP = MaxHP;
        EnemyAnimatorStateInfo = EnemyAnimator.GetCurrentAnimatorStateInfo(0);
    }

    private void Update()
    {
        if (isHurt)
        {
            HurtTimePass += Time.deltaTime;
            if (HurtTimePass >= 0.25f)
            {
                HurtTimePass = 0;
                isHurt = false;
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            }
        }
        EnemyAnimatorStateInfo = EnemyAnimator.GetCurrentAnimatorStateInfo(0);
        TimePass -= Time.deltaTime;
        SetZ();
        Aim();
        HPBar.value = HP / MaxHP;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        MoveDirection = -MoveDirection;
    }
}
