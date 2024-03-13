using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Movement : MonoBehaviour
{
    [SerializeField] public float moveSpeedConst = 5f;
    [SerializeField] public float moveSpeed = 5f;

    [SerializeField] private Rigidbody2D rb;
    
    public bool DashActive = false;
    public Vector2 MovementDir;
    private Vector2 dashMovement;

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + MovementDir * moveSpeed * Time.fixedDeltaTime);
    }
}


