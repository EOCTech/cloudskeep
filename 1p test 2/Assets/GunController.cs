using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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
    public bool canFire = true;
    public static int TargetCount = 0;
    public int HealItemCount = 0;
    public float maxHealth = 100.0f;
    public float playerHealth = 0.0f;
    public GameObject healItem;
    public GameObject cameraModel;
    public static bool playerDead = false;
    public GameObject CameraControl;
    public GameObject rigidbodyFirstPersonController;


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

        if (playerHealth <= 0 && !playerDead)
        {
            StartCoroutine(PlayerDeath());
            print("death");
        }


        if (Input.GetButtonDown("Fire1"))
        {
            if (canFire)
            {
                StartCoroutine(FireWeapon());
            }
        }

        if (Input.GetKey(KeyCode.Y))
        {
            if (HealItemCount < 6)
            {
                Instantiate(healItem, targetSpawn.transform.position, targetSpawn.transform.rotation);
                TargetCount = TargetCount + 1;
            }

        }

        if (Input.GetButtonDown("Fire2"))
        {
            if (TargetCount < 6)
            {
                Instantiate(target, targetSpawn.transform.position, targetSpawn.transform.rotation);
                TargetCount = TargetCount + 1;
            }
        }

        IEnumerator FireWeapon()
        {
            canFire = false;
            // set target to end position
            gunTarget.transform.position = GunEndPosition.transform.position;
            // wait 0.2 sec
            yield return new WaitForSeconds(0.2f);
            // set target back to start position
            gunTarget.transform.position = GunStartPosition.transform.position;

            Instantiate(bullet, GunStartPosition.transform.position, GunStartPosition.transform.rotation);
            yield return new WaitForSeconds(0.4f);
            canFire = true;
        }

        IEnumerator PlayerDeath()
        {
            if (playerHealth <= 0)
            {
                playerDead = true;
                cameraModel.transform.Rotate(10, 0, 0);
                yield return new WaitForSeconds(0.1f);
                cameraModel.transform.Rotate(10, 0, 0);
                yield return new WaitForSeconds(0.1f);
                cameraModel.transform.Rotate(10, 0, 0);
                yield return new WaitForSeconds(0.1f);
                cameraModel.transform.Rotate(10, 0, 0);
                if (EditorApplication.isPlaying)
                {
                    UnityEditor.EditorApplication.isPlaying = false;
                }
            }

        }
    }
}
