using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Movement : MonoBehaviour
{
    [SerializeField] public float moveSpeedConst = 5f;
    [SerializeField] public float moveSpeed = 5f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D hitbox;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private Sprite playerLeft;
    [SerializeField] private Sprite playerRight;
    [SerializeField] private Sprite playerIdle;


    public bool dashActive;
    public Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");//try hash(?)
        movement.y = Input.GetAxisRaw("Vertical");//try hash(?)
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //dash  check probably
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //dash  check probably

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //dash  check probably

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //dash  check probably

        }
        if (Input.GetKeyDown(KeyCode.Z))//seperate into different class
        {
            moveSpeed = 2f;
            hitbox.GetComponent<BoxCollider2D>().size = new Vector2(35f, 35f);

        }
        else if (Input.GetKeyUp(KeyCode.Z))//seperate into different class
        {
            moveSpeed = moveSpeedConst;
            hitbox.GetComponent<BoxCollider2D>().size = new Vector2(100, 80f);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))//seperate into different class
        {
            playerSprite.sprite = playerLeft;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))//seperate into different class
        {
            playerSprite.sprite = playerIdle;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))//seperate into different class
        {
            playerSprite.sprite = playerRight;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))//seperate into different class
        {
            playerSprite.sprite = playerIdle;
        }

    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}


