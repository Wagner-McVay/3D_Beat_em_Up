using UnityEngine;
using System.Collections;

[RequireComponent (typeof (BoxCollider))]
public class Hazard : MonoBehaviour {

	private GameObject GameController;
	public float Damage = 10;
	public float Delay = 1;
	public Color hazardColor;
	private float lastDelay;
	private bool playerState = false;
	private bool enemyState = false;
	private GameObject player;
	private GameObject[] Enemys;

	void OnDrawGizmos() {
		Gizmos.color = hazardColor;
		Gizmos.DrawCube(transform.position + GetComponent<BoxCollider>().center,GetComponent<BoxCollider>().size);
	}

	void Start()
	{
		GameController = GameObject.FindGameObjectWithTag("GameController");
		Damage = GameController.GetComponent<GameActor>().Hazard_Damage;
		Delay = GameController.GetComponent<GameActor>().Hazard_Delay;

	}

	void OnTriggerEnter(Collider c)
	{
		if (Enemys == null) Enemys = GameObject.FindGameObjectsWithTag("Enemy");
		if (player == null) player = GameObject.FindGameObjectWithTag("Player");
		if (c.tag == "Player") 
		{
			if (c.gameObject != null)
			{
				c.gameObject.GetComponent<PlayerActor>().takingDamage = true;
				playerState = true;
			}
			else playerState = false;
		}
		if (c.tag == "Enemy") 
		{
			if (c.gameObject != null)
			{
				c.gameObject.GetComponent<EnemyActor>().takingDamage = true;
				enemyState = true;
			}
			else enemyState = false;
		}
	}

	void Update()
	{

		if(playerState != false || enemyState != false)
		{
			if(Time.time > Delay+lastDelay)
			{
				if (player != null)
				if (player.GetComponent<PlayerActor>().takingDamage == true)
				{
					if (player != null)
					player.GetComponent<PlayerActor>().TakeDamage(Damage);
				}
				if (Enemys != null)
				for (int i = 0; i < Enemys.Length; i++ )
				{
					if (Enemys[i] != null)
					if (Enemys[i].GetComponent<EnemyActor>().takingDamage == true)
					{
						Enemys[i].GetComponent<EnemyActor>().TakeDamage(Damage);
					}
				}
				lastDelay = Time.time;
			}
		}
	}

	void OnTriggerExit(Collider c)
	{
		if (c.tag == "Player") 
		{
			c.gameObject.GetComponent<PlayerActor>().takingDamage = false;
			playerState = false;
		}
		if (c.tag == "Enemy") 
		{
			c.gameObject.GetComponent<EnemyActor>().takingDamage = false;
			enemyState = false;
		}
	}
}
