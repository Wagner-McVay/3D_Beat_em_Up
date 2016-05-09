using UnityEngine;
using System.Collections;

public class EnemyActor : MonoBehaviour {

	private CharacterController controller;
	private float offset;
	private float Timer = 0;
	private bool Jump = false;
	private float Y = -8;
	public Transform target;
	public float Enemy_HP = 100;
	public float BaseSpeed = 1f;
	public float JumpHeight = 1;
	public float Gravity = 1;
	// take damage function
	public void TakeDamage(int x){
		Enemy_HP -= x;
	}

	// Use this for initialization
	void Start () {
		controller = gameObject.GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		Timer += Time.deltaTime;

		Vector3 finalTargetPosition = target.position;

		// if the player is to the right of the enemy
		if (target.position.x > transform.position.x) {
			finalTargetPosition.x -= 0.25f;
		} else {
			finalTargetPosition.x += 0.25f;
		}

		// calculate the direction
		Vector3 targetDirection = finalTargetPosition - transform.position;
		targetDirection.y = 0f;
		targetDirection.Normalize ();

		// figure out how fast this should be going
		float finalSpeed = BaseSpeed;
		float distanceToTarget = Vector3.Distance (transform.position, finalTargetPosition);
		// if enemy is alive
		if (Enemy_HP > 0) {
			// x2 speed when far from player
			if (distanceToTarget > 2f) {
				finalSpeed = BaseSpeed * 2;
			}
			// x1 speed when near player
			if (distanceToTarget < 2f && distanceToTarget > 0.075f) {
				finalSpeed = BaseSpeed;
			}
			// 
			if (distanceToTarget < 0.8f && distanceToTarget > 0.075f) {
				if (target.position.y > transform.position.y + 0.5f) {
					if (Jump == false) {
						Y = (JumpHeight + 3);			
					}
					Jump = true;
				}
			}
			// stop when next to player
			if (distanceToTarget < 0.075f) {
				finalSpeed = 0f;
			}

			if (Y > -8) {
				Y -= (Gravity / 4);
			} else {
				Y = -8;
			}
			Vector3 move_direction = new Vector3 (0, Y, 0);
			controller.Move (move_direction * Time.deltaTime);

			// apply the changes to position
			controller.Move (targetDirection * finalSpeed * Time.deltaTime);
		}
	}

	// if enemy touches ground allow jump
	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		LayerMask mask = LayerMask.GetMask ("Ground");
		
		if ((mask.value & 1 << hit.gameObject.layer) == 1 << hit.gameObject.layer) {
			Jump = false;
		}
	}

	// if player enters right Hitbox do right attack
	void OnTrigger1Enter(Collider ATK1)
	{

	}

	// if player enters left Hitbox do left attack
	void OnTrigger2Enter(Collider ATK2)
	{

	}
	
}

