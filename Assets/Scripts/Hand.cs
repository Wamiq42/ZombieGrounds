using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : Weapon
{
    public Animator handAnimator;
    public override void WeaponAttributes()
    {
        magSize = 0;
        bullets = magSize;
        bulletDestroyTimer = 0;
        bullet = null;
        bulletSpawnLocation = null;
        animator = handAnimator;
    }


}
