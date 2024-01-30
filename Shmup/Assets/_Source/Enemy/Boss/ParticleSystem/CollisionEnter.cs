using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerMovement;

public class CollisionEnter : MonoBehaviour
{

    void OnParticleCollision(GameObject other)
    {
        
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(1);
        }

    }
}
