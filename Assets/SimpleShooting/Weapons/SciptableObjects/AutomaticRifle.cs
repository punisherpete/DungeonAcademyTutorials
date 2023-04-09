using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapons/AutomaticRifle")]
public class AutomaticRifle : Weapon
{
    [SerializeField] private float fireRate;

    private float nextFireTime;

    public override void Shoot()
    {
        base.Shoot();

        while (Input.GetButton("Fire1"))
        {
            if (Time.time >= nextFireTime)
            {
                nextFireTime = Time.time + 1f / fireRate;

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
    }
}
