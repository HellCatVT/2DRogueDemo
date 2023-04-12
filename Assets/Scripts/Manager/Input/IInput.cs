using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInput
{

    /// <summary>
    /// 人物移动方向
    /// </summary>
    /// <returns>人物移动的单位向量</returns>
    public Vector2 MoveDirection();

    /// <summary>
    /// 人物攻击
    /// </summary>
    public bool IsAttack();

    /// <summary>
    /// 人物技能释放
    /// </summary>
    public bool IsSkilRelease();

    /// <summary>
    /// 人物更换武器
    /// </summary>
    public bool IsSwitchWeapon();


    /// <summary>
    /// 光标指向的位置
    /// </summary>
    /// <returns>光标的世界坐标</returns>
    public Vector2 PointPosition();

    public bool IsMenuButton();

}
