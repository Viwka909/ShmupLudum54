using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform FirePoint;

    public GameObject bulletPrefab;

    float firerate = 0.2f;
    float canfire = 0.2f;

    void Update()
    {
        if (Input.GetKey(KeyCode.Z) && Time.time > canfire)
        {
            ShootAct();
            canfire = Time.time + firerate;
        }

    }

    void ShootAct()
    {
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
    }
    
}
