using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    [HideInInspector]
    private bool isAttaking;

    public float MoveSpeed = 1;

    public Animator EnemyAnimator;

    public AnimatorStateInfo EnemyAnimatorStateInfo;

    public Transform FirePointTF;

    public Transform EnemySprite;

    public int ATK;

    public float ATKRate;

    public float BulletSpeed;

    public float HP;

    public float MaxHP = 100;

    public int EXP;

    [HideInInspector]
    public float TimePass;

    [HideInInspector]
    public Vector3 AimDirection;

    [HideInInspector]
    public Quaternion AimRotation;

    [HideInInspector]
    public Vector2 MoveDirection;

    public GameObject BulletOBJ;

    public Slider HPBar;

    public AudioSource Audio;

    public Action EnemyDeadCount;

    public bool isHurt;



    public void SetZ()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y / 100);
    }


    /// <summary>
    /// 控制瞄准方向
    /// </summary>
    /// <param name="SR"></param>
    public void Aim()
    {
        AimDirection = new Vector2(
            GameManager.Instance.Player.transform.position.x - transform.position.x,
            GameManager.Instance.Player.transform.position.y - transform.position.y
            );
        if (AimDirection.x < 0)
            EnemySprite.localScale = new(-1, 1, 1);

        else
        {
            EnemySprite.localScale = new(1, 1, 1);
        }
            
        float angle = Vector2.Angle(Vector2.right, AimDirection);
        if (AimDirection.y < 0)
            angle *= -1;
        AimRotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public void RandomMoveDirection()
    {
        System.Random random = new System.Random();
        float x = random.Next(-2, 2);
        float y = random.Next(-2, 2);
        if (x == 0)
            x = AimDirection.x;
        if (y == 0)
            y = AimDirection.y;
        MoveDirection = new Vector2(x, y).normalized;
    }

    public void GetDamaged(float Damage)
    {
        Audio.Play();
        HP -= Damage;
    }



}
