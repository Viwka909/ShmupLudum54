using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Boss : MonoBehaviour
{
     public int hp;
     public int halfhp;
   
   public GameObject Phase1;
   public GameObject Phase2;
   Wave wave;
   void Start()
   {
    wave = GameObject.Find("Wave").GetComponent<Wave>();
   }
   void Update()
   {
     if(hp <= halfhp){
            Debug.Log(123);
            Phase1.SetActive(false);
            Phase2.SetActive(true);
        }
   }
    
    public void TakeDamage(int dmg)
    {
        
        hp -= dmg;
        Debug.Log(hp);
        if (hp <= 0)
        { 
            Die();
        }
       
    }

     void Die(){
        wave.BossKilled();
        Destroy(gameObject);
     }  
}
