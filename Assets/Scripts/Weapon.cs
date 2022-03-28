using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected int magSize;
    protected int bullets;
    protected GameObject bullet;
    protected float bulletDestroyTimer;
    protected float fireRate;
    protected Transform bulletSpawnLocation;
    protected Animator animator;
    protected GameManager gameManager;
    protected AudioSource audioSourceFire;
    protected AudioSource audioSourceReload;
    GameObject tempPistolBullet = null;
    public virtual void WeaponAttributes()
    {
        magSize = 0;
        bullets = magSize;
        bulletDestroyTimer = 0;
        bullet = null;
        bulletSpawnLocation = null;
        animator = null;
    }
    public virtual void Melee()
    {
        if(Input.GetButtonDown("Fire1"))
            animator.SetTrigger("Fire");
    }
    public virtual void Fire()
    {

        if (Input.GetButtonDown("Fire1") && bullets > 0)
        {
            if(tempPistolBullet == null)
            {
                animator.SetTrigger("Fire");
                audioSourceFire.Play();
                tempPistolBullet = Instantiate(bullet,
                bulletSpawnLocation.position, bulletSpawnLocation.rotation);
                Debug.Log(bullets);
                bullets--;
                Destroy(tempPistolBullet, bulletDestroyTimer);
            }
        }
        else if(Input.GetButtonDown("Fire1") && bullets<=0)
        {
            gameManager.SetReload(true);
            Debug.Log("R to Reload");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
            animator.SetTrigger("Reload");
            audioSourceReload.Play();
            gameManager.SetReload(false);
        }
    }

    public void SetGameManager(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }


    public void Reload()
    {
        bullets = magSize-1;
    }

    public float FireRate()
    {
        return bulletDestroyTimer;
    }
    public int GetBullets()
    {
        return bullets;
    }
    public Animator GetAnimator()
    {
        return animator;
    }
    public virtual GameObject GetBullet()
    {
        return bullet;
    }
    public Transform BulletSpawnLocation()
    {
        return bulletSpawnLocation;
    }
}
