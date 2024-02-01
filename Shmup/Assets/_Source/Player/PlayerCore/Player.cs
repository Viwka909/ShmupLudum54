using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSys
{
    public class Player : MonoBehaviour
    {
       
        [SerializeField] private PlayerSys.Damage damage;
        [SerializeField] private Animator Death;
        [SerializeField] private Animator GameOver;
        public GameObject[] Health = new GameObject[4];
        public int hp = 5;

        public void TakeDamage(int dmg)
        {
            damage.TakeDamage(hp,this);
            if (hp <= 0)
            {
                StartCoroutine(Die());
            }
        }
        IEnumerator Die()
        {
            Death.SetTrigger("Death");
            GameOver.SetTrigger("GameOver");
            yield return new WaitForSeconds(0.35f);
            Destroy(gameObject);
        }


    }

}
