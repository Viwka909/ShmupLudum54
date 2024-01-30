using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMovement
{
    public class PlayerDash : MonoBehaviour
    {
        Vector2 movement;
        public void Dash(Rigidbody2D rb, int dir)
        {
            if (dir == 1)
            {
                movement.Set(-1,0);//left
                rb.MovePosition(rb.position + movement * 15 * Time.fixedDeltaTime);
            }
            else if (dir == 2)
            {
                movement.Set(0,1);//up
                rb.MovePosition(rb.position + movement * 15 * Time.fixedDeltaTime);
            }
            else if (dir == 3)
            {
                movement.Set(0,-1);//down
                rb.MovePosition(rb.position + movement * 15 * Time.fixedDeltaTime);
            }
            else if (dir == 4)
            {
                movement.Set(1,0);//right
                rb.MovePosition(rb.position + movement * 15 * Time.fixedDeltaTime);
            }
            
        }
    }

}
