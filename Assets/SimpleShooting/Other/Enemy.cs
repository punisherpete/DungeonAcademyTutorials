using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, IDieable
{
    [SerializeField] private float health;

    public void GetDamage(float damage)
    {
        Debug.Log($"{damage} recieved");
        health -= damage;

        if(health <= 0)
        {
            health = 0;
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Поминки");
        Destroy(gameObject);
    }
}
