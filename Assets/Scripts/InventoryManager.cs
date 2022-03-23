using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager
{
    EquippedGun equippedGun;

    public delegate void GunEquip(EquippedGun equipped);
    public GunEquip gunEquip;

    public InventoryManager()
    {
        equippedGun = EquippedGun.hands;
    }

    public void SetEquippedGun(EquippedGun equipped)
    {
        equippedGun = equipped;
        gunEquip?.Invoke(equippedGun);
    }


}
public enum EquippedGun {hands,pistol,AssaultRifle}
