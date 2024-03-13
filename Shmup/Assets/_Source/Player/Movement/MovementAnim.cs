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
          Debug.Log(playerSprite.sprite.name);
        playerSprite.sprite = playerLeft;
        Debug.Log(playerSprite.sprite.name);
    }
    public void MoveRight()
    {
        playerSprite.sprite = playerRight;
    }
    public void MoveIdle()
    {
        Debug.Log(123);
        playerSprite.sprite = playerIdle;
    }

}
