﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerActor : MonoBehaviour
{

    private CharacterController controller;
    private Animator anim;
    private Rigidbody2D rb2d;
    private SpriteRenderer SpRe;
    private GameObject ATK_R;
    private GameObject ATK_L;
    private GameObject NME_1;
    private GameObject NME_2;
    private GameObject NME_3;
    private GameObject NME_4;
    private bool Jump = false;
    [HideInInspector]
    public bool facingRight = true;
    private float Y = -8;
    private bool Direction = true;
    public float Player_HP = 100;
    public float JumpHeight = 1;
    public float Speed = 1;
    public float Gravity = 1;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        SpRe = GetComponent<SpriteRenderer>();
        controller = gameObject.GetComponent<CharacterController>();
        ATK_R = GameObject.Find("R_HitBox");
        ATK_L = GameObject.Find("L_HitBox");
        NME_1 = GameObject.Find("Enemy 1");
        NME_2 = GameObject.Find("Enemy 2");
        NME_3 = GameObject.Find("Enemy 3");
        NME_4 = GameObject.Find("Enemy 4");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Idle State for animations
        if (!Input.anyKey)
        {
            anim.SetTrigger("Idle");
            anim.ResetTrigger("Walking");
            anim.ResetTrigger("Jumping");
            anim.ResetTrigger("Attack");
        }

        //Attack state
        if (Input.GetKeyDown(KeyCode.K))
        {
            
            anim.SetTrigger("Attack");

            

        }

        // Gravity and jump
        if (true)
        {
            if (Y > -8)
            {
                Y -= (Gravity / 4);
            }
            else Y = -8;

            if (Input.GetKey(KeyCode.Space))
            {
                anim.SetTrigger("Jumping");
                anim.ResetTrigger("Idle"); anim.ResetTrigger("Walking");
                if (Jump == false)
                {
                    
                    Y = (JumpHeight + 4);
                }
                Jump = true;
                
            }

            Vector3 move_direction = new Vector3(0, Y, 0); //heh, boobs
            controller.Move(move_direction * Time.deltaTime);
        }

        //		float hVal = Input.GetAxis ("Horizontal");
        //		float vVal = Input.GetAxis ("Vertical");
        //		vVal *= 0.5f;
        //
        //		Vector3 moveDirection = new Vector3 (hVal, 0f, vVal);
        //		moveDirection *= Time.deltaTime * (Speed * 2);
        //		controller.Move (moveDirection);

        // WSAD movement
        float h = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.W))
        {
            Vector3 move_direction = new Vector3(0, 0, Speed + 0.5f);
            controller.Move(move_direction * Time.deltaTime);
            anim.SetTrigger("Walking"); anim.ResetTrigger("Idle");

        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 move_direction = new Vector3(0, 0, -Speed - 0.5f);
            controller.Move(move_direction * Time.deltaTime);
            anim.SetTrigger("Walking"); anim.ResetTrigger("Idle");
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 move_direction = new Vector3(-Speed - 1, 0, 0);
            controller.Move(move_direction * Time.deltaTime);
            anim.SetTrigger("Walking"); anim.ResetTrigger("Idle");
            Direction = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 move_direction = new Vector3(Speed + 1, 0, 0);
            controller.Move(move_direction * Time.deltaTime);
            anim.SetTrigger("Walking"); anim.ResetTrigger("Idle");
            Direction = true;
        }

        

        if (h > 0 && !facingRight)
        {
            Flip();
        }
        else if (h < 0 && facingRight)
        {
            Flip();
        }


        //		if (Input.GetKeyDown (KeyCode.Keypad1)) {
        //
        //			if (Direction == true){
        //				OnTriggerEnter(ATK_R);
        //			}
        //			else{
        //				OnTriggerEnter(ATK_L);
        //			}
        //		}
    }



    // if player touches ground allow jump
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        LayerMask mask = LayerMask.GetMask("Ground");

        if ((mask.value & 1 << hit.gameObject.layer) == 1 << hit.gameObject.layer)
        {
            anim.ResetTrigger("Jumping");
            Jump = false;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Attack()
    {

    }

    // if player attack hits an enemy
    //	void OnTriggerEnter(GameObject x)	{
    //		NME_1.GetComponent<EnemyActor>().TakeDamage(1);
    //	}
}
