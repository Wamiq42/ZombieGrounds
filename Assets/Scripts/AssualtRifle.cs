using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssualtRifle : Weapon
{
    public GameObject bulletPrefab;
    public Transform bulletLocation;
    public Animator assaultAnimator;

    private List<GameObject> tempBullets;
    private int bulletsFiredperClick = 4;
    //private float nextBulletSpawn = 0.0f;
    public override void WeaponAttributes()
    {
        magSize = 32;
        bullets = magSize;
        bulletDestroyTimer = 1.0f;
        fireRate = 0.2f;
        bullet = bulletPrefab;
        bulletSpawnLocation = bulletLocation;
        animator = assaultAnimator;
        tempBullets = new List<GameObject>();
    }
    public override void Fire()
    {
        if (Input.GetButtonDown("Fire1") && bullets > 0)
        {
                animator.SetTrigger("Fire");
                for (int i = 0; i < bulletsFiredperClick; i++)
                {
                   
                    tempBullets.Add(Instantiate(bullet, bulletSpawnLocation.position, bulletSpawnLocation.rotation));
                    Debug.Log(bullets);
                    bullets--;
                }

                DestroyBullets();
            
        }
        else if (Input.GetButtonDown("Fire1") && bullets <= 0)
        {
            Debug.Log("R to Reload");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
        
    }


  
    void DestroyBullets()
    {
       
        for (int i = 0; i < tempBullets.Count; i++)
        {
            Destroy(tempBullets[i], bulletDestroyTimer);
            //Debug.Log(tempBullets.Count);
        }
    }
}
