using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    private Transform shootingPoint;

    [field: SerializeField] public int Damage { get; protected set; }
    [field: SerializeField] public int MaxAmmo { get; protected set; }
    [SerializeField] protected float shootingRange;
    [field: SerializeField] public Sprite Icon { get; protected set; }
    [field: SerializeField] public GameObject Prefab { get; protected set; }

    public int CurrentAmmo { get; protected set; }
    public bool IsReloading { get; protected set; } = false;

    public virtual void InitWeapon(Transform shootingPoint)
    {
        this.shootingPoint = shootingPoint;
        CurrentAmmo = MaxAmmo;
    }

    public virtual void Shoot()
    {
        if (shootingPoint == null)
        {
            throw new Exception("Shooting point not Initialized!");
        }
            

        if(CurrentAmmo <= 0)
        {
            Debug.Log("Out of ammo!");
            Reload();
            return;
        }

        PerformShot();
    }

    public virtual void Reload()
    {
        if (IsReloading || CurrentAmmo == MaxAmmo)
        {
            return;
        }

        IsReloading = true;
        Debug.Log("Reloading...");

        CurrentAmmo = MaxAmmo;
        IsReloading = false;
    }

    protected virtual void PerformShot()
    {
        CurrentAmmo--;
        RaycastHit hitInfo;

        if (Physics.Raycast(shootingPoint.position, (shootingPoint.transform.forward + Camera.main.transform.forward).normalized, out hitInfo, shootingRange))
        {
            Debug.Log(hitInfo.collider.name + " shot!");
        }
    }
}
