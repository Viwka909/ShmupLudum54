using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingEnemy : MonoBehaviour
{
    public Rigidbody2D rb;

    public Transform FirePoint;
    public GameObject bulletPrefab;
    public AudioSource Fire;
    public float firerate = 0.2f;
    public float canfire = 0.2f;
    private Transform target;
    private Vector3 direction;
    private float angle;

    void Start()
    {
        target = GameObject.FindObjectOfType<Player>().transform;
    }
    void Update()
    {


        if (Time.time > canfire)
        {

            StartCoroutine(ShootAct());

            canfire = Time.time + firerate;
        }
    }

    IEnumerator ShootAct()
    {
        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(0.5f);
            Fire.Play();
            Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        }


    }

    void FixedUpdate()
    {
        direction = target.position - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90f, Vector3.forward);
    }
}
