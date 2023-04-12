using Game.Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public GameObject PlayerPrefab;

    public GameObject Player;

    private IInput gameInput;

    public int kills = 0;

    public int BossKills = 0;

    public IInput GameInput{ get { return gameInput; } }


    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
        SetInputDevice();
    }


    /// <summary>
    /// 设置输入设备
    /// </summary>
    private void SetInputDevice()
    {
        gameInput = new KeyBoardInput();
        Debug.Log("KeyBoard!");
    }


    /// <summary>
    /// 生成玩家
    /// </summary>


}
