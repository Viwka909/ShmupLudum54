using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = -8f;
    public int dmg = 1;
    public Rigidbody2D Rb;
 

    void Start()
    {
        Rb.velocity = transform.up * speed;
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            
            player.TakeDamage(dmg);
        }
        Destroy(gameObject);
    }
}
