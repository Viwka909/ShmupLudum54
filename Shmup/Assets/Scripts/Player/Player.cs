using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp = 5;

    public float invulduration;
    public int flashes;
    public Collider2D hitbox;
    public SpriteRenderer playerSprite;
    public Sprite Damaged;
    public GameObject[] Health = new GameObject[4];
    public GameObject HpPercent;
    public Sprite[] Percentage = new Sprite[4];
    public AudioSource DamageSound;
    public Animator Death;
    public Animator GameOver;

    int count = 0;
   

    public void TakeDamage(int dmg)
    {
        DamageSound.Play();
        hp -= dmg;
        Health[count].GetComponent<SpriteRenderer>().sprite = Damaged;
        HpPercent.GetComponent<SpriteRenderer>().sprite = Percentage[count];
        count++;
        StartCoroutine(HurtInvul());
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

    IEnumerator HurtInvul(){
        hitbox.enabled = false;
        Physics2D.IgnoreLayerCollision(6,7,true);
        for (int i = 0; i < flashes; i++)
        {
            Physics2D.IgnoreLayerCollision(6,10,true);
            playerSprite.color = new Color(1,1,1, 0.7f);
            yield return new WaitForSeconds(invulduration/flashes);
            playerSprite.color = Color.white;
            Physics2D.IgnoreLayerCollision(6,10,true);
            yield return new WaitForSeconds(invulduration/flashes);
            Physics2D.IgnoreLayerCollision(6,10,true);
        }
        Physics2D.IgnoreLayerCollision(6,10,false);
        hitbox.enabled = true;
    }
}
