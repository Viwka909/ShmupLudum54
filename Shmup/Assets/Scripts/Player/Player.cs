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

    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        StartCoroutine(HurtInvul());
        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    IEnumerator HurtInvul(){
        hitbox.enabled = false;
        Debug.Log("begin");
        for (int i = 0; i < flashes; i++)
        {
            playerSprite.color = new Color(0,0,0, 0.3f);
            yield return new WaitForSeconds(invulduration/flashes);
            playerSprite.color = Color.white;
            yield return new WaitForSeconds(invulduration/flashes);
        }
        Debug.Log("end");
        hitbox.enabled = true;
    }
}
