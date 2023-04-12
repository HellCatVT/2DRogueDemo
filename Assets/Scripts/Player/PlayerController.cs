using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class PlayerController : Singleton<PlayerController>
{
    public SpriteRenderer PlayerSpriteRenderer;

    public SpriteRenderer WeaponSpriteRenderer;

    private PlayerStats PlayerInfo;//玩家数据

    public int HP;

    public static Action PlayerDie;

    private float ATKTimeCount;

    public GameObject CurrentWeapon;

    private int EXPGain;

    public Action<int> GetHurt;

    public AudioSource MoveAudio;

    public Animator PlayerAnimator;

    public SpriteRenderer PlayerSprite;
    

    // Start is called before the first frame update
    void Start()
    {
        MoveAudio.pitch = 1.5f;
        DontDestroyOnLoad(this);
        PlayerInfo = GetComponent<PlayerStats>();
        SetHP();
        PlayerDie += SetHP;
        ATKTimeCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        SetFlip();
        Attack();
        SetZ();
        if(GameManager.Instance.GameInput.MoveDirection().magnitude < 0.1f)
            PlayerAnimator.SetBool("IsRun", false);
        else
            PlayerAnimator.SetBool("IsRun", true);
    }

    void FixedUpdate()
    {
        Move();
        SetMoveAudio();
    }

    /// <summary>
    /// 设置Z轴确保遮挡关系
    /// </summary>
    private void SetZ()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.y / 100);
    }

    /// <summary>
    /// 玩家移动
    /// </summary>
    /// 

    private void SetFlip()
    {
        if(GameManager.Instance.GameInput.PointPosition().x < transform.position.x)
        {
            PlayerSprite.flipX = true;
        }
        else
            PlayerSprite.flipX = false;
    }

    private void SetMoveAudio()
    {
        if(GameManager.Instance.GameInput.MoveDirection().sqrMagnitude < 0.1f)
            MoveAudio.Pause();
        else
        {
            if(!MoveAudio.isPlaying)
                MoveAudio.Play();
        }
            
            
    }

    private void Move()
    {
        gameObject.transform.Translate(GameManager.Instance.GameInput.MoveDirection() * PlayerInfo.MoveSpeed * Time.fixedDeltaTime);
        if(GameManager.Instance.GameInput.MoveDirection().x < 0)
            PlayerSpriteRenderer.flipX = true;
        else
            PlayerSpriteRenderer.flipX = false;
    }

    /// <summary>
    /// 玩家攻击
    /// </summary>
    private void Attack()
    {
        ATKTimeCount -= Time.deltaTime;
        if (ATKTimeCount <= 0 && GameManager.Instance.GameInput.IsAttack())
        {
            ATKTimeCount = CurrentWeapon.GetComponent<Weapon>().ATKRate;
            CurrentWeapon.GetComponent<Weapon>().Attack();
        }
    }

    /// <summary>
    /// 玩家受伤
    /// </summary>
    /// <param name="Damage">伤害</param>
    public void GetDamaged(int Damage)
    {
        GetHurt?.Invoke(Damage);
        HP -= Damage;
        if (HP <= 0)
        {
            Die();
        }
    }

    public int GetHP()
    {
        return HP;
    }

    /// <summary>
    /// 玩家死亡
    /// </summary>
    public void Die()
    {
        PlayerAnimator.SetBool("IsDie", true);
        StaticUpdate();
        PlayerDie?.Invoke();
    }


    /// <summary>
    /// 重置血量
    /// </summary>
    public void SetHP()
    {
        HP = PlayerInfo.MaxHP;
    }

    public void GainEXP(int exp)
    {
        EXPGain += exp;
    }

    /// <summary>
    /// 设置数据
    /// </summary>
    private void StaticUpdate()
    {
        if (PlayerInfo.MaxKills < GameManager.Instance.kills)
            PlayerInfo.MaxKills = GameManager.Instance.kills;
        PlayerInfo.Kills = GameManager.Instance.kills;
        PlayerInfo.BossKills = GameManager.Instance.BossKills;
        PlayerInfo.EXPGain = EXPGain;
        PlayerInfo.EXP += PlayerInfo.EXPGain;
        PlayerInfo.AllKills += PlayerInfo.Kills;
        PlayerInfo.AllBossKills += PlayerInfo.BossKills;
        PlayerInfo.DieCount++;
        EXPGain = 0;
        GameManager.Instance.kills = 0;
        GameManager.Instance.BossKills = 0;
    }

    public void ResetPlayerInfo()
    {
        PlayerInfo.Kills = 0;
        PlayerInfo.BossKills = 0;
        PlayerInfo.EXPGain = 0;
    }

}
