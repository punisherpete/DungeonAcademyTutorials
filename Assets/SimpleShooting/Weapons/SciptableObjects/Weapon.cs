using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    private Transform shootingPoint;

    [field: SerializeField] public int Damage { get; protected set; }
    [field: SerializeField] public int MaxAmmo { get; protected set; }
    [field: SerializeField] public Sprite Icon { get; protected set; }
    [field: SerializeField] public GameObject Prefab { get; protected set; }

    [SerializeField] protected float shootingRange;

    public int CurrentAmmo { get; protected set; }
    public bool IsReloading { get; protected set; } = false;

    public virtual void InitWeapon(Transform shootingPoint)
    {
        this.shootingPoint = shootingPoint;
    }

    public virtual void Shoot()
    {
        if (shootingPoint == null)
            throw new Exception("Shooting point not Initialized!");
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
        RaycastHit hitInfo;

        if (Physics.Raycast(shootingPoint.position, shootingPoint.transform.forward + Camera.main.transform.forward, out hitInfo, shootingRange))
        {
            Debug.Log(hitInfo.collider.name);
        }
    }
}
