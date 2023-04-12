using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletPlayer : Bullet
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        BulletMove();
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        EffectGenerate();
    }



}
