using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New Data", menuName ="PlayerStats/Data")]
public class PlayerStat_SO : ScriptableObject
{
    [Header("Stats Info")]
    public int MaxHP;

    public float MoveSpeed;

    public int BossKills;

    public int Kills;

    public int MaxKills;

    public int DieCount;

    public int EXPGain;

    public int EXP;

    public int AllKills;

    public int AllBossKills;




}
