using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapons/AutomaticRifle")]
public class AutomaticRifle : Weapon
{
    [SerializeField] private float fireRate;

    private float nextFireTime;

    public override void InitWeapon()
    {
        base.InitWeapon();

        nextFireTime = 0;
    }

    public override async void Shoot()
    {
        while (Input.GetMouseButton(0))
        {
            int cooldown = (int)(1000 / fireRate);
            await Task.Delay(cooldown);
            base.Shoot();
        }
    }
}
