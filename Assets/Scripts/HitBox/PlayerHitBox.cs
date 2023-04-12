using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBox : HitBox
{
    public override void OnHit()
    {
        GameManager.Instance.Player.GetComponent<PlayerController>().GetDamaged((int)damage);
    }
}
