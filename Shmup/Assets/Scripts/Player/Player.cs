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
    int count = 0;
   

    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        Health[count].GetComponent<SpriteRenderer>().sprite = Damaged;
        HpPercent.GetComponent<SpriteRenderer>().sprite = Percentage[count];
        count++;
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
            playerSprite.color = new Color(1,1,1, 0.7f);
            yield return new WaitForSeconds(invulduration/flashes);
            playerSprite.color = Color.white;
            yield return new WaitForSeconds(invulduration/flashes);
        }
        Debug.Log("end");
        hitbox.enabled = true;
    }
}
