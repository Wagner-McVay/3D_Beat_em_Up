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
	public float RangeAttackSpeed;
	public float RangeAttackDecay;
	public bool takingDamage = false;
	public GameObject RangeAttackPrefab;
	Animator animator;

	[SerializeField]
	private int PlayerID;

	// Use this for initialization
	void Start () {
		controller = gameObject.GetComponent<CharacterController>();
		GameController = GameObject.FindGameObjectWithTag("GameController");
		animator = gameObject.GetComponent<Animator>();

		PlayerSettings playerSett = GameController.GetComponent<PlayerSettings>();
		PlayerID = (int)playerSett.Players - 1;
		HP = playerSett.Data[PlayerID].PlayerHP;
		MP = playerSett.Data[PlayerID].PlayerMP;
		Damage = playerSett.Data[PlayerID].PlayerDamage;
		Armor = playerSett.Data[PlayerID].PlayerArmor;
		JumpVal = playerSett.Data[PlayerID].PlayerJump;
		Speed = playerSett.Data[PlayerID].PlayerSpeed;
		Gravity = playerSett.Data[PlayerID].PlayerGravity;
		RangeAttackSpeed = playerSett.Data[PlayerID].RangeAttackSpeed;
		RangeAttackDecay = playerSett.Data[PlayerID].RangeAttackDecay;
		RangeAttackPrefab = GameController.GetComponent<EnemySettings>().EnemyTypes[PlayerID].RangeAttackPrefab;
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		//Checks to see what the current animation state is
		if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") ||
		    this.animator.GetCurrentAnimatorStateInfo(0).IsName("Move") || 
		    this.animator.GetCurrentAnimatorStateInfo(0).IsName("Shoot_Move") ||
		    this.animator.GetCurrentAnimatorStateInfo(0).IsName("Shoot_Idle"))
		{
			
			float curSpeed = Mathf.Abs(Speed * Input.GetAxis("Vertical")) + Mathf.Abs(Speed * Input.GetAxis("Horizontal"));
			animator.SetFloat("Speed", curSpeed);
			
			float angleMedian = 0;
			float arrowsPressed = 0;
			if (Input.GetKey(KeyCode.A))
			{
				transform.position += new Vector3(-1, 0, 0) * Speed * Time.deltaTime;
				//transform.eulerAngles = new Vector3(0,270,0);
				angleMedian += 270;
				arrowsPressed++;
			}
			if (Input.GetKey(KeyCode.D))
			{
				transform.position += new Vector3(1, 0, 0) * Speed * Time.deltaTime;
				//transform.eulerAngles = new Vector3(0, 90, 0);
				angleMedian += 90;
				arrowsPressed++;
			}
			if (Input.GetKey(KeyCode.W))
			{
				transform.position += new Vector3(0, 0, 1) * Speed * Time.deltaTime;
				//    transform.eulerAngles = new Vector3(0, 0, 0);
				if (Input.GetKey(KeyCode.A))
				{
					angleMedian = 315;
				}
				else
				{
					arrowsPressed++;
				}
			}
			if (Input.GetKey(KeyCode.S))
			{
				transform.position += new Vector3(0, 0, -1) * Speed * Time.deltaTime;
				//transform.eulerAngles = new Vector3(0, 180, 0);
				
				angleMedian += 180;
				arrowsPressed++;
			}
			if (arrowsPressed > 0)
			{
				transform.eulerAngles = new Vector3(0, angleMedian / arrowsPressed, 0);
			}
			
			
			if (Input.GetKey(KeyCode.Mouse0))
			{
				animator.SetTrigger("ConstFire");
			}
			//else { animator.ResetTrigger("ConstFire"); }
			
			if (Input.GetKeyDown(KeyCode.Mouse1))
			{
				animator.SetTrigger("Melee");
			}
		}
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			animator.SetTrigger("Fire");
		}
		if (Input.GetKey(KeyCode.Mouse0))
		{
			animator.SetTrigger("ConstFire");
		}
		else { animator.ResetTrigger("ConstFire"); }
		
		if (Input.GetKeyDown(KeyCode.Mouse1))
		{
			animator.SetTrigger("Melee");
		}

		// Gravity and jump
		if (1 > 0) {
			if (Y > -8)	{
				Y -= (Gravity / 4);
			}
			else Y = -8;
			
			if (Input.GetKey (KeyCode.Space)) {
				if (isGrounded == false) {
					Y = (JumpVal+3);			
				}
				isGrounded = true;
			}
			
			Vector3 move_direction = new Vector3 (0, Y, 0);
			controller.Move (move_direction * Time.deltaTime);
		}
	}

	// if player touches ground allow jump
	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		LayerMask mask = LayerMask.GetMask ("Ground");
		
		if ((mask.value & 1 << hit.gameObject.layer) == 1 << hit.gameObject.layer) {
			isGrounded = false;
		}
	}

//	{

//		float hVal = Input.GetAxis ("Horizontal");
//		float vVal = Input.GetAxis ("Vertical");
//		vVal *= 0.5f;
//
//		Vector3 moveDirection = new Vector3 (hVal, 0f, vVal);
//		moveDirection *= Time.deltaTime * (Speed * 2);
//		controller.Move (moveDirection);

		// WSAD movement
//		if (Input.GetKey (KeyCode.W)) {
//			Vector3 move_direction = new Vector3 (0, 0, Speed+0.5f);
//			controller.Move (move_direction * Time.deltaTime);
//		}
//		if (Input.GetKey (KeyCode.S)) {
//			Vector3 move_direction = new Vector3 (0, 0, -Speed-0.5f);
//			controller.Move (move_direction * Time.deltaTime);
//		}
//		if (Input.GetKey (KeyCode.A)) {
//			Vector3 move_direction = new Vector3 (-Speed-1, 0, 0);
//			controller.Move (move_direction * Time.deltaTime);
////			Direction = false;
//		}
//		if (Input.GetKey (KeyCode.D)) {
//			Vector3 move_direction = new Vector3 (Speed+1, 0, 0);
//			controller.Move (move_direction * Time.deltaTime);
////			Direction = true;
//		}


	void BigBullet()
	{
		GameObject TempBullet;
		Vector3 pos = gameObject.transform.position;
		Vector3 rot = gameObject.transform.rotation.eulerAngles;
		TempBullet = Instantiate(RangeAttackPrefab, pos, Quaternion.Euler(rot)) as GameObject;
		TempBullet.AddComponent<BulletData>();

		if (gameObject.transform.rotation.y == 0)
			TempBullet.transform.position += new Vector3(0, .45f, .2f);
		if (gameObject.transform.rotation.y == 90)
			TempBullet.transform.position += new Vector3(.2f, .45f, 0);
		if (gameObject.transform.rotation.y == 180)
			TempBullet.transform.position += new Vector3(0, .45f, -.2f);
		if (gameObject.transform.rotation.y == 270)
			TempBullet.transform.position += new Vector3(-.2f, .45f, 0);

		Rigidbody TempBulletRigidBody;
		TempBulletRigidBody = TempBullet.GetComponent<Rigidbody>();
		
		TempBulletRigidBody.AddForce(transform.forward * RangeAttackSpeed);
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
}

