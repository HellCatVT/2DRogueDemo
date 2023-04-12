using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon_Pistol : Weapon
{
    public Vector2 Point;

    public AudioSource ShootAudio;

    private void Start()
    {
        ShootAudio.pitch = 1.5f;
    }

    private void Update()
    {

        Point = GameManager.Instance.GameInput.PointPosition();
        WeaponAim();
    }
    public override void Attack()
    {
        ShootAudio.Play();
        GameObject bullet = Instantiate(Bullet,FirePosition.position,transform.rotation);
        bullet.GetComponent<BulletPlayer>().ATK = WeaponATK;
        bullet.GetComponent<BulletPlayer>().BulletSpeed = BulletSpeed;
    }

    
}
