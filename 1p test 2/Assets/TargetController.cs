using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public GameObject bullet;
    public float health = 100.0f;
    public GameObject target;

    public void Update()
    {
        if (health <= 100)
        {
            Object.Destroy(target);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        health = health - BulletController.damage;
    }
}
