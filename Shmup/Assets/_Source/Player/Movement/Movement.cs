using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Movement : MonoBehaviour
{
    [SerializeField] public float moveSpeedConst = 5f;
    [SerializeField] public float moveSpeed = 5f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private Sprite playerLeft;
    [SerializeField] private Sprite playerRight;
    [SerializeField] private Sprite playerIdle;
    

    public bool DashActive = false;
    public Vector2 MovementDir;
    private Vector2 dashMovement;

    void Update()
    {
        
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
        rb.MovePosition(rb.position + MovementDir * moveSpeed * Time.fixedDeltaTime);
    }
}


