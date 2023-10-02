using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   public int hp = 5;
   public AudioSource DamageSound;
    
    public void TakeDamage(int dmg)
    {
        DamageSound.Play();
        hp -= dmg;
        if (hp <= 0)
        { 
            Die();
        }
    }

     void Die(){
        Destroy(gameObject);
     }   
}
