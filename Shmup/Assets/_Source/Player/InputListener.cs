using System.Collections;
using System.Collections.Generic;
using PlayerMovement;
using UnityEngine;

public class InputListener : MonoBehaviour
{
  [SerializeField] private GameObject playerObject;
  private Movement playerMovement;
  private PlayerDash dash;
  void Start()
  {
    playerMovement = playerObject.GetComponent<Movement>();
    dash = playerObject.GetComponent<PlayerDash>();
  }
  void Update()
  {
    playerMovement.movement.x = Input.GetAxisRaw("Horizontal");
    playerMovement.movement.y = Input.GetAxisRaw("Vertical");
    if (Input.GetKeyDown(KeyCode.LeftShift))
    {
      dash.Dash();
    }
  }
}
