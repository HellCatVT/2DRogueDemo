using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using TMPro.EditorUtilities;
#endif
using Unity.VisualScripting;
using UnityEngine;

public abstract class HitBox : MonoBehaviour
{
    protected float damage;
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            damage = collision.GetComponent<Bullet>().ATK;
            OnHit();
            collision.GetComponent<Bullet>().EffectGenerate();
            Destroy(collision.gameObject);
        }
            
    }

    public abstract void OnHit();
}
