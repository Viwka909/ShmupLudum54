using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Movement : MonoBehaviour
    {
        public float moveSpeedConst = 5f;
        public float moveSpeed = 5f;
        public float dashSpeed = 40f;
        public Rigidbody2D rb;
        public Camera cam;
        public float dashTime = 0.1f;
        public float dashCd = 2f;
        public Collider2D hitbox;
        public SpriteRenderer playerSprite;
        

        Vector2 movement;
        int dashcheck = 0;
        bool candash = true;
        float clicktime = 0;
        float clickdelay = 0.3f;



        void Update()
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (dashcheck != 1 && candash == true)
                {
                    dashcheck = 1;
                    clicktime = 0;
                    clicktime = Time.time;
                }
                else if (dashcheck == 1 && Time.time - clicktime < clickdelay)
                {
                    dashcheck = 0;
                    moveSpeed = dashSpeed;
                    candash = false;
                    StartCoroutine(DashReturn());
                }
                else
                {
                    dashcheck = 0;
                }
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (dashcheck != 2 && candash == true)
                {
                    dashcheck = 2;
                    clicktime = 0;
                    clicktime = Time.time;
                }
                else if (dashcheck == 2 && Time.time - clicktime < clickdelay)
                {
                    dashcheck = 0;
                    moveSpeed = dashSpeed;
                    candash = false;
                    StartCoroutine(DashReturn());
                }
                else
                {
                    dashcheck = 0;
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (dashcheck != 3 && candash == true)
                {
                    dashcheck = 3;
                    clicktime = 0;
                    clicktime = Time.time;
                }
                else if (dashcheck == 3 && Time.time - clicktime < clickdelay)
                {
                    dashcheck = 0;
                    moveSpeed = dashSpeed;
                    candash = false;
                    StartCoroutine(DashReturn());
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (dashcheck != 4 && candash == true)
                {
                    dashcheck = 4;
                    clicktime = 0;
                    clicktime = Time.time;
                }
                else if (dashcheck == 4 && Time.time - clicktime < clickdelay)
                {
                    dashcheck = 0;
                    moveSpeed = dashSpeed;
                    candash = false;
                    StartCoroutine(DashReturn());
                }
                else
                {
                    dashcheck = 0;
                }
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                moveSpeed = 2f;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                moveSpeed = moveSpeedConst;
            }
        }
        void FixedUpdate()
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        IEnumerator DashReturn()
        {
            hitbox.enabled = false;
            playerSprite.color = Color.blue;
            yield return new WaitForSeconds(dashTime);
            hitbox.enabled = true;
            playerSprite.color = Color.white;
            moveSpeed = moveSpeedConst;
            yield return new WaitForSeconds(dashCd);
            candash = true;
            
        }
    }


