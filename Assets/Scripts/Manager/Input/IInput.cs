using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInput
{

    /// <summary>
    /// �����ƶ�����
    /// </summary>
    /// <returns>�����ƶ��ĵ�λ����</returns>
    public Vector2 MoveDirection();

    /// <summary>
    /// ���﹥��
    /// </summary>
    public bool IsAttack();

    /// <summary>
    /// ���＼���ͷ�
    /// </summary>
    public bool IsSkilRelease();

    /// <summary>
    /// �����������
    /// </summary>
    public bool IsSwitchWeapon();


    /// <summary>
    /// ���ָ���λ��
    /// </summary>
    /// <returns>������������</returns>
    public Vector2 PointPosition();

    public bool IsMenuButton();

}
