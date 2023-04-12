using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : MonoBehaviour
{

    public Enemy enemy;



    protected float damage;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Bullet")
        {
            if (enemy.HP > 0)
            {
                enemy.isHurt = true;
                enemy.GetComponent<Rigidbody2D>().velocity = new(-enemy.AimDirection.normalized.x * 3, -enemy.AimDirection.normalized.y * 3);
            }
            float damage = collision.GetComponent<Bullet>().ATK;
            enemy.GetDamaged(damage);
            collision.GetComponent<Bullet>().EffectGenerate();
            Destroy(collision.gameObject);
        }

    }

}
