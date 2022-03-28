using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public GameObject bulletPrefab;
    public Transform bulletLocation;
    public Animator pistolAnimator;
    public AudioSource[] pistolAudioSources;
    
    //
    private GameObject tempBullet;
    public override void WeaponAttributes()
    {
        magSize = 7;
        bullets = magSize;
        bulletDestroyTimer = 0.8f;
        bullet = bulletPrefab;
        bulletSpawnLocation = bulletLocation;
        animator = pistolAnimator;
        audioSourceFire = pistolAudioSources[0];
        audioSourceReload = pistolAudioSources[1];
       
    }



}
