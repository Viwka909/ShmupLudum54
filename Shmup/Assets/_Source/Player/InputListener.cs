using System.Collections;
using System.Collections.Generic;
using PlayerMovement;
using UnityEngine;

public class InputListener : MonoBehaviour
{
  [SerializeField] private GameObject playerObject;
  [SerializeField] private Movement playerMovement;
  [SerializeField] private PlayerDash dash;
  [SerializeField] private Shrink shrink;
  [SerializeField] private MovementAnim moveAnim;

  void Start()
  {

  }
  void Update()
  {

    if (playerMovement.DashActive == false)
    {
      if (Input.GetKeyDown(KeyCode.LeftArrow))
      {
        Debug.Log(123);
        moveAnim.MoveLeft();
      }
      else if (Input.GetKeyUp(KeyCode.LeftArrow))
      {
        moveAnim.MoveIdle();
      }
      if (Input.GetKeyDown(KeyCode.RightArrow))
      {
        moveAnim.MoveRight();
      }
      else if (Input.GetKeyUp(KeyCode.RightArrow))
      {
       moveAnim.MoveIdle();
      }
      playerMovement.MovementDir.x = Input.GetAxisRaw("Horizontal");
      playerMovement.MovementDir.y = Input.GetAxisRaw("Vertical");

      if (Input.GetKeyDown(KeyCode.Z))
      {
        shrink.StartShrink();
      }
      else if (Input.GetKeyUp(KeyCode.Z))
      {
        shrink.EndShrink();
      }
    }
    if (Input.GetKeyDown(KeyCode.LeftShift))
    {
      dash.Dash();
    }
  }
}
