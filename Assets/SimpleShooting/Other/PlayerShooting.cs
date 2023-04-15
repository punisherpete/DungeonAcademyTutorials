using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform weaponSpawnPosition;
    [SerializeField] private List<Weapon> weapons;

    private Weapon currentWeapon;

    private void Start()
    {
        foreach (var weapon in weapons)
        {
            Instantiate(weapon.Prefab, weaponSpawnPosition);
            weapon.InitWeapon();
        }

        currentWeapon = weapons[0];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentWeapon.Shoot();
        }
    }
}
