using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    
    [Header("����������")]
    public int WeaponATK;

    public GameObject Bullet;

    public Transform FirePosition;

    public float ATKRate = 2;

    public float BulletSpeed;

    public SpriteRenderer WeaPonSpriteRenderer;


    /// <summary>
    /// ��������
    /// </summary>
    public abstract void Attack();

    /// <summary>
    /// ����ָ��
    /// </summary>
    public void WeaponAim()
    {
        Vector2 dir = new Vector2(
            GameManager.Instance.GameInput.PointPosition().x - transform.position.x,
            GameManager.Instance.GameInput.PointPosition().y - transform.position.y
            );
        if(dir.x<0)
            WeaPonSpriteRenderer.flipY = true;
        else
            WeaPonSpriteRenderer.flipY = false;
        float angle = Vector2.Angle(Vector2.right,dir);
        if (dir.y < 0)
            angle *= -1;
        transform.eulerAngles = new Vector3(0,0,angle);
    }
}
