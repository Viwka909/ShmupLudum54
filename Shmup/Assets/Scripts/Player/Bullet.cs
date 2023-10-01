using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   public float speed = 8f;
    public int dmg = 1;
    public Rigidbody2D Rb;

    void Start()
    {
        Rb.velocity = transform.up * speed;
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null){
            enemy.TakeDamage(dmg);
        }
        Destroy(gameObject);
    }
}
