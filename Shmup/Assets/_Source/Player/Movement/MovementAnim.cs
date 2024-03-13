using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovementAnim : MonoBehaviour
{
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private Sprite playerLeft;
    [SerializeField] private Sprite playerRight;
    [SerializeField] private Sprite playerIdle;

    public void MoveLeft()
    {
 
        if (playerSprite.sprite == playerIdle)
        {
            playerSprite.sprite = playerLeft;
        }
    }
    public void MoveRight()
    {
        if (playerSprite.sprite == playerIdle)
        {
            playerSprite.sprite = playerRight;
        }
    }
    public void MoveIdle()
    {
        Debug.Log(123);
        if (playerSprite.sprite == playerRight || playerSprite.sprite == playerLeft)
        {
            playerSprite.sprite = playerRight;
        }
    }
}
