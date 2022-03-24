using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public GameObject bulletPrefab;
    public Transform bulletLocation;
    public Animator pistolAnimator;
    public override void WeaponAttributes()
    {
        magSize = 7;
        bullets = magSize;
        bulletDestroyTimer = 1.2f;
        bullet = bulletPrefab;
        bulletSpawnLocation = bulletLocation;
        animator = pistolAnimator;
    }


}
