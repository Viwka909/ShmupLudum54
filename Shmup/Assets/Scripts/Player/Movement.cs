using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public class Movement : MonoBehaviour
    {
        public float moveSpeedConst = 5f;
        public float moveSpeed = 5f;
        public float dashSpeed = 40f;
        public Rigidbody2D rb;
        public Camera cam;
        public float dashTime = 0.5f;
        public float dashCd = 2f;
        public Collider2D hitbox;
        public SpriteRenderer playerSprite;
        public Sprite playerLeft;
        public Sprite playerRight;
         public Sprite playerIdle;
        public Image DodgeGauge;
        public Animator Dodge;
        public AudioSource DodgeSound;
        

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
            if (Input.GetKeyDown(KeyCode.Z))
            {
                moveSpeed = 2f;
                hitbox.GetComponent<BoxCollider2D>().size = new Vector2(35f,35f);

            }
            else if (Input.GetKeyUp(KeyCode.Z))
            {
                moveSpeed = moveSpeedConst;
                hitbox.GetComponent<BoxCollider2D>().size = new Vector2(100,80f);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                playerSprite.sprite = playerLeft;
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                playerSprite.sprite = playerIdle;
            }
             if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                playerSprite.sprite = playerRight;
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                playerSprite.sprite = playerIdle;
            }
            if(candash == false){
                DodgeGauge.fillAmount += 1/ dashCd * Time.deltaTime;
                if( DodgeGauge.fillAmount >= 1){
                    DodgeGauge.fillAmount = 1;
                }
            }
        }
        void FixedUpdate()
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        IEnumerator DashReturn()
        {
            DodgeSound.Play();
            Dodge.SetTrigger("Dodged");
            Physics2D.IgnoreLayerCollision(6,10,true);
            hitbox.enabled = false;
            playerSprite.color = new Color(1,1,1,0.7f);
            DodgeGauge.fillAmount = 0;
            yield return new WaitForSeconds(dashTime);
            hitbox.enabled = true;
            Physics2D.IgnoreLayerCollision(6,10,false);
            playerSprite.color = Color.white;
            moveSpeed = moveSpeedConst;
            yield return new WaitForSeconds(dashCd);
            candash = true;
            
            
        }
    }


