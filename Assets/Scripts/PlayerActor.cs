using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class PlayerActor : MonoBehaviour {

        private CharacterController controller;
        private GameObject GameController;
        private bool isGrounded = false;
        private float Y = -8;
        //	private bool Direction = true;
        public float HP;
        public float MP;
        public float Damage;
        public float Armor;
        public float JumpVal;
        public float Speed;
        public float Gravity;
        public bool takingDamage = false;

        [SerializeField]
        private int PlayerID;

        // Use this for initialization
        void Start() {
            controller = gameObject.GetComponent<CharacterController>();
            GameController = GameObject.FindGameObjectWithTag("GameController");

            PlayerSettings playerSett = GameController.GetComponent<PlayerSettings>();
            PlayerID = (int)playerSett.Players - 1;
            HP = playerSett.Data[PlayerID].PlayerHP;
            MP = playerSett.Data[PlayerID].PlayerMP;
            Damage = playerSett.Data[PlayerID].PlayerDamage;
            Armor = playerSett.Data[PlayerID].PlayerArmor;
            JumpVal = playerSett.Data[PlayerID].PlayerJump;
            Speed = playerSett.Data[PlayerID].PlayerSpeed;
            Gravity = playerSett.Data[PlayerID].PlayerGravity;

        }

        // Update is called once per frame
        void FixedUpdate()
        {

            // Gravity and jump
            if (1 > 0) {
                if (Y > -8) {
                    Y -= (Gravity / 4);
                }
                else Y = -8;

                if (Input.GetKey(KeyCode.Space)) {
                    if (isGrounded == false) {
                        Y = (JumpVal + 3);
                    }
                    isGrounded = true;
                }

                Vector3 move_direction = new Vector3(0, Y, 0);
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
            if (Input.GetKey(KeyCode.W)) {
                Vector3 move_direction = new Vector3(0, 0, Speed + 0.5f);
                controller.Move(move_direction * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S)) {
                Vector3 move_direction = new Vector3(0, 0, -Speed - 0.5f);
                controller.Move(move_direction * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A)) {
                Vector3 move_direction = new Vector3(-Speed - 1, 0, 0);
                controller.Move(move_direction * Time.deltaTime);
                //			Direction = false;
            }
            if (Input.GetKey(KeyCode.D)) {
                Vector3 move_direction = new Vector3(Speed + 1, 0, 0);
                controller.Move(move_direction * Time.deltaTime);
                //			Direction = true;
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

            if ((mask.value & 1 << hit.gameObject.layer) == 1 << hit.gameObject.layer) {
                isGrounded = false;
            }
        }

        public void TakeDamage(float dmg)
        {
            float x = dmg - Armor;
            if (x < 0) x = 0;
            HP -= x;

            if (HP <= 0)
            {
                HP = 0;
                Die();
            }
        }

        public float getHP()
        {
            return HP;
        }

        public float getMP()
        {
            return MP;
        }

        public void Die()
        {
            Destroy(this.gameObject);
        }

        // if player attack hits an enemy
        //	void OnTriggerEnter(GameObject x)	{
        //		NME_1.GetComponent<EnemyActor>().TakeDamage(1);
        //	}
        //>>>>>>> refs/remotes/origin/master
    }


