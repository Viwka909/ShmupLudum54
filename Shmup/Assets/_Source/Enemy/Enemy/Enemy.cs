using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   public int hp = 1;
   public AudioSource DamageSound;
   Wave wave;
    
    void Start()
   {
    wave = GameObject.Find("Wave").GetComponent<Wave>();
   }
    public void TakeDamage(int dmg)
    {
        DamageSound.Play();
        hp -= dmg;
        if (hp <= 0)
        { 
           Debug.Log("kill"); 
           wave.EnemyKilled();
            Die();
        }
    }

     void Die(){
        
        Destroy(gameObject);
     }   
}
