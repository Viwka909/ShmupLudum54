using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerMovement;

public class CollisionEnter : MonoBehaviour
{

    void OnParticleCollision(GameObject other)
    {
        
        PlayerSys.Player player = other.GetComponent<PlayerSys.Player>();
        if (player != null)
        {
            player.TakeDamage(1);
        }

    }
}
