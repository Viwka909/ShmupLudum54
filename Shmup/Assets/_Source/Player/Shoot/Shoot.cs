using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform FirePoint;

    public GameObject bulletPrefab;
    public GameObject WeapToggle;
    public Sprite ToggleOn;
    public Sprite ToggleOff;
    public AudioSource Fire;
    

    float firerate = 0.2f;
    float canfire = 0.2f;
    bool toggle;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (toggle == true)
            {
                toggle = false;
                WeapToggle.GetComponent<SpriteRenderer>().sprite = ToggleOff;
            }
            else
            {
                toggle = true;
                WeapToggle.GetComponent<SpriteRenderer>().sprite = ToggleOn;
            }
        }

        if (toggle == true && Time.time > canfire)
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
