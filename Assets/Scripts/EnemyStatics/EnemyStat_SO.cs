using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data",menuName = "EnemyStats/Data")]
public class EnemyStat_SO : ScriptableObject
{
    [Header("Stats Info")]
    public float MoveSpeed = 1;

    public int ATK;

    public float ATKRate;

    public float BulletSpeed;

    public float MaxHP;
}
