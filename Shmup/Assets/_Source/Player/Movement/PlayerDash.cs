using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerMovement
{
    public class PlayerDash : MonoBehaviour
    {
        [SerializeField] private AudioSource DodgeSound;
        [SerializeField] private Movement plrmovement;
        [SerializeField] private Animator Dodge;
        [SerializeField] private Collider2D hitbox;
        [SerializeField] private SpriteRenderer playerSprite;
        [SerializeField] private Image DodgeGauge;
        [SerializeField] private float dashTime = 0.5f;
        [SerializeField] private float dashCd = 2f;
        [SerializeField] private float dashSpeed = 40f;
        public bool candash = true;
        void Update()
        {
            if (candash == false)
            {
                
                DodgeGauge.fillAmount += 1 / dashCd * Time.deltaTime;
                if (DodgeGauge.fillAmount >= 1)
                {
                    DodgeGauge.fillAmount = 1;
                }
            }
        }
        public void Dash()
        {
            if (candash)
            {
                candash = false;
                plrmovement.DashActive = true;
                plrmovement.moveSpeed = dashSpeed;
                StartCoroutine(DashReturn());
            }
        }
        IEnumerator DashReturn()
        {
            DodgeSound.Play();
            Dodge.SetTrigger("Dodged");//try hash
            Physics2D.IgnoreLayerCollision(6, 10, true);
            hitbox.enabled = false;
            playerSprite.color = new Color(1, 1, 1, 0.7f);
            DodgeGauge.fillAmount = 0;
            yield return new WaitForSeconds(dashTime);
            plrmovement.DashActive = false;
            hitbox.enabled = true;
            Physics2D.IgnoreLayerCollision(6, 10, false);
            playerSprite.color = Color.white;
            plrmovement.moveSpeed = plrmovement.moveSpeedConst;
            yield return new WaitForSeconds(dashCd);
            candash = true;

        }
    }

}
