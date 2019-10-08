using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bullet;
    public float thrust = 1500.0f;
    public Rigidbody rb;
    public GameObject Gun;
    public static float damage;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(bullet.transform.forward * -thrust);
        Object.Destroy(bullet, 1.0f);
        damage = 50.0f;
    }

}
