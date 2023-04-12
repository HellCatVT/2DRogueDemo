using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    
    [Header("武器攻击力")]
    public int WeaponATK;

    public GameObject Bullet;

    public Transform FirePosition;

    public float ATKRate = 2;

    public float BulletSpeed;

    public SpriteRenderer WeaPonSpriteRenderer;


    /// <summary>
    /// 攻击方法
    /// </summary>
    public abstract void Attack();

    /// <summary>
    /// 武器指向
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
