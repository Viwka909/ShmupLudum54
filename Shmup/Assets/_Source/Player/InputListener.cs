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
  void Start()
  {
    /*playerMovement = playerObject.GetComponent<Movement>();
    dash = playerObject.GetComponent<PlayerDash>();
    shrink = playerObject.GetComponent<Shrink>();*/
  }
  void Update()
  {
    if (playerMovement.DashActive == false)
    {
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
