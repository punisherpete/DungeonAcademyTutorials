using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapons/Handgun")]
public class Handgun : Weapon
{
    public override void Shoot()
    {
        base.Shoot();

        if (CurrentAmmo > 0)
        {
            PerformShot();
            CurrentAmmo--;
        }
        else
        {
            Debug.Log("Out of ammo.");
            Reload();
        }
    }
}