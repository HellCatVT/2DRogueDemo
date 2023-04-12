using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBullet : Bullet
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        BulletMove();
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        EffectGenerate();
        Destroy(gameObject);
    }

    public void RocketEffectGenerate()
    {
        GameObject effect =  Instantiate(EffectOBJ, EffectPoint.position,Quaternion.identity);
    }
}
