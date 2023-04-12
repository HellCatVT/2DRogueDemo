using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public PlayerStat_SO PlayerData;

    #region Read from PlayerData
    public int MaxHP
    {
        get {if(PlayerData != null)  return PlayerData.MaxHP; else return 0; }
        set {MaxHP = value;}
    }

    public float MoveSpeed
    {
        get { if (PlayerData != null) return PlayerData.MoveSpeed; else return 0; }
        set { MoveSpeed = value; }
    }
    public int Kills
    {
        get { if (PlayerData != null) return PlayerData.Kills; else return 0; }
        set { PlayerData.Kills = value; }
    }
    public int BossKills
    {
        get { if (PlayerData != null) return PlayerData.BossKills; else return 0; }
        set { PlayerData.BossKills = value; }
    }
    public int MaxKills
    {
        get { if (PlayerData != null) return PlayerData.MaxKills; else return 0; }
        set { PlayerData.MaxKills = value; }
    }

    public int DieCount
    {
        get { if (PlayerData != null) return PlayerData.DieCount; else return 0; }
        set { PlayerData.DieCount = value; }
    }

    public int EXPGain
    {
        get { if (PlayerData != null) return PlayerData.EXPGain; else return 0; }
        set { PlayerData.EXPGain = value; }
    }

    public int AllKills
    {
        get { if (PlayerData != null) return PlayerData.AllKills; else return 0; }
        set { PlayerData.AllKills = value; }
    }
    public int AllBossKills
    {
        get { if (PlayerData != null) return PlayerData.AllBossKills; else return 0; }
        set { PlayerData.AllBossKills = value; }
    }

    public int EXP
    {
        get { if (PlayerData != null) return PlayerData.EXP; else return 0; }
        set { PlayerData.EXP = value; }
    }


    #endregion
}
