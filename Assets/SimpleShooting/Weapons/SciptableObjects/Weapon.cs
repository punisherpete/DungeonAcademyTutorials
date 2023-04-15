using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    [field: SerializeField] public int Damage { get; protected set; }
    [field: SerializeField] public int MaxAmmo { get; protected set; }
    [SerializeField] protected float shootingRange;
    [SerializeField] protected float reloadCooldown;
    [field: SerializeField] public GameObject Prefab { get; protected set; }

    public int CurrentAmmo { get; protected set; }
    public bool IsReloading { get; protected set; } = false;

    public virtual void InitWeapon()
    {
        CurrentAmmo = MaxAmmo;
    }

    public virtual void Shoot()
    {       
        if(CurrentAmmo <= 0)
        {
            Debug.Log("Out of ammo!");
            Reload();
            return;
        }

        PerformShot();
    }

    public async virtual void Reload()
    {
        if (IsReloading || CurrentAmmo == MaxAmmo)
        {
            return;
        }

        IsReloading = true;
        Debug.Log("Reloading...");

        await Task.Delay((int)(reloadCooldown * 1000));

        CurrentAmmo = MaxAmmo;
        IsReloading = false;

        Debug.Log("Reload Finished");
    }

    protected virtual void PerformShot()
    {
        CurrentAmmo--;

        RaycastHit hitInfo;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo, 100))
        {
            if (hitInfo.transform.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.GetDamage(Damage);
            }
        }
    }
}
