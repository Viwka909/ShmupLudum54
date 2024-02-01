using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSys
{
    public class Damage : MonoBehaviour
    {
        [SerializeField] private AudioSource damageSound;
        [SerializeField] private GameObject hpPercent;
        [SerializeField] private float invulduration;
        [SerializeField] private SpriteRenderer playerSprite;
        [SerializeField] private Sprite[] percentage = new Sprite[4];
        [SerializeField] private Collider2D hitbox;
        [SerializeField] private Sprite damaged;
        [SerializeField] private  int flashes;
        private int count = 0;
        public void TakeDamage(int dmg, Player Plr)
        {
            damageSound.Play();
            Plr.hp -= dmg;
            Plr.Health[count].GetComponent<SpriteRenderer>().sprite = damaged;
            hpPercent.GetComponent<SpriteRenderer>().sprite = percentage[count];
            count++;
            StartCoroutine(HurtInvul());
        }
        IEnumerator HurtInvul()
        {
            hitbox.enabled = false;
            Physics2D.IgnoreLayerCollision(6, 7, true);
            for (int i = 0; i < flashes; i++)
            {
                Physics2D.IgnoreLayerCollision(6, 10, true);
                playerSprite.color = new Color(1, 1, 1, 0.7f);
                yield return new WaitForSeconds(invulduration / flashes);
                playerSprite.color = Color.white;
                Physics2D.IgnoreLayerCollision(6, 10, true);
                yield return new WaitForSeconds(invulduration / flashes);
                Physics2D.IgnoreLayerCollision(6, 10, true);
            }
            Physics2D.IgnoreLayerCollision(6, 10, false);
            hitbox.enabled = true;
        }
    }
}

