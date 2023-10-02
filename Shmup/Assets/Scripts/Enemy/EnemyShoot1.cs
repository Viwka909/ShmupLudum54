using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot1 : MonoBehaviour
{
    public Transform FirePoint;

    public GameObject bulletPrefab;
    public AudioSource Fire;
    

    float firerate = 0.5f;
    float canfire = 0.5f;



    void Update()
    {
        

     if ( Time.time > canfire)
        {
            
                ShootAct();
            canfire = Time.time + firerate;
            
            
        }
    }

    void ShootAct()
    {
        Fire.Play();
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
    }
}
