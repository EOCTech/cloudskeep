using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    public GameObject gunModel;
    public GameObject gunTarget;
    public float speed;
    public GameObject GunStartPosition;
    public GameObject GunEndPosition;
    public Rigidbody rb;
    public GameObject bullet;
    public GameObject target;
    public GameObject targetSpawn;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 100.0f;
        gunTarget.transform.position = gunModel.transform.position;
        Vector3 offset = new Vector3(0.0f, 0.0f, 0.5f);
        GunEndPosition.transform.position = gunModel.transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        gunModel.transform.position = Vector3.Lerp(gunModel.transform.position, gunTarget.transform.position, 0.1f * Time.deltaTime * speed);

        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(FireWeapon());
        }

        if (Input.GetButtonDown("Fire2"))
        {
            Instantiate(target, targetSpawn.transform.position, targetSpawn.transform.rotation);
        }

        IEnumerator FireWeapon()
        {
            // set target to end position
            gunTarget.transform.position = GunEndPosition.transform.position;
            // wait 0.2 sec
            yield return new WaitForSeconds(0.2f);
            // set target back to start position
            gunTarget.transform.position = GunStartPosition.transform.position;

            Instantiate(bullet, GunStartPosition.transform.position, GunStartPosition.transform.rotation);
        }

    }
}
