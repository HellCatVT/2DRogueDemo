using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{

    public float ATK;

    public float BulletSpeed;

    public Transform EffectPoint;

    public GameObject EffectOBJ;
    /// <summary>
    /// ×Óµ¯ÒÆ¶¯
    /// </summary>
    protected void BulletMove()
    {
        transform.Translate(BulletSpeed * Time.fixedDeltaTime,0,0);
    }

    public void EffectGenerate()
    {
        Instantiate(EffectOBJ, EffectPoint.position, transform.rotation);
    }

    public abstract void OnCollisionEnter2D(Collision2D collision);
}
