using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrink : MonoBehaviour
{
    [SerializeField] private Movement plrmovement;
    [SerializeField] private float slowSpeed = 2f;
    [SerializeField] private float shrinkedHitboxHeight = 35f;
    [SerializeField] private float shrinkedHitboxWidth = 35f;
    [SerializeField] private float normalHitboxHeight = 80f;
    [SerializeField] private float normalHitboxWidth = 100f;
    [SerializeField] private Collider2D hitbox;//брать сразу коллайдер

    public void StartShrink()
    {
        plrmovement.moveSpeed = slowSpeed;
        hitbox.GetComponent<BoxCollider2D>().size = new Vector2(shrinkedHitboxWidth, shrinkedHitboxHeight);//hash vectors
    }
    public void EndShrink()
    {
        plrmovement.moveSpeed = plrmovement.moveSpeedConst;
        hitbox.GetComponent<BoxCollider2D>().size = new Vector2(normalHitboxWidth, normalHitboxHeight);
    }
}
