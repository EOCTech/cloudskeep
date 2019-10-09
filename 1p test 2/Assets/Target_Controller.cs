using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Controller : MonoBehaviour
{
    public GameObject gun;
    public GameObject bullet;
    public float maxHealth = 100.0f;
    public float health = 100.0f;
    public GameObject target;

    public void Update()
    {
        if (health <= 0)
        {
            Object.Destroy(target);
            GunController.TargetCount = GunController.TargetCount - 1;
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            health = health - BulletController.damage;
            Object.Destroy(other.gameObject, 0.1f);
        }
    }
}
