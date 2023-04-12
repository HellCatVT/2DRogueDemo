using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : Enemy
{


    public Transform RocketFirePintTF;

    public GameObject RocketOBJ;

    public GameObject FlamingArea;

    public int RocketATK;

    public int FlamingATK;

    public float RocketSpeed;

    public float RocketRate;

    public float RocketTimePass;

    public float FlamingRate;

    public float FlamingTimePass;

    public AudioClip LaunchRocket;

    public AudioClip Firing;
    
    public AudioClip Flaming;

    public AudioClip Die;

    public GameObject TransDoor;

    public GameObject BossHPBarOBJ;

    public Slider HPSlider;

    // Start is called before the first frame update
    void Start()
    {
        ResetFlamingTimePass();
        ResetRocketTimePass();
        ResetTimePass();
        HP = MaxHP;
        EnemyAnimatorStateInfo = EnemyAnimator.GetCurrentAnimatorStateInfo(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(isHurt)
            GetComponent<Rigidbody2D>().velocity = new(0,0);
        if (HPSlider != null)
        {
            HPSlider.value = HP / MaxHP;
        }
        EnemyAnimatorStateInfo = EnemyAnimator.GetCurrentAnimatorStateInfo(0);
        SetZ();
        Aim();
    }

    public void ResetTimePass()
    {
        TimePass = ATKRate;
    }

    public void ResetRocketTimePass()
    {
        RocketTimePass = RocketRate+ Random.Range(0, 1);
    }

    public void ResetFlamingTimePass()
    {
        FlamingTimePass = FlamingRate + Random.Range(0, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        MoveDirection = AimDirection.normalized;
    }


}
