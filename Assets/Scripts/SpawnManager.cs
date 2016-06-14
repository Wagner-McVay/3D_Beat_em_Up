using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour 
{

	public GameObject[] Prefabs;			// stores Prefabs
	public GameObject EnemyUI;				// stores EnemyUI Prefab
	private GameObject currentPlayer;		// stores current instantiated player
	private GameObject[] currentEnemy;		// stores current instantiated Enemies
	private GameObject[] currentEnemyUI;	// stores current instantiated Enemy UI's
	private GameObject[] PlayerSpawnPoints;	// stores all player Spawn Points
	private GameObject[] EnemySpawnPoints;	// stores all Enemy Spawn Points
	private CameraActor cam;				// used for getting camrea to lock on to player after instantiation
	private EnemyActor[] nme;				// used for getting enemies to lock on to player after instantiation
	private PlayerSettings PlayerSett;		// used to reference Player variables
//	private EnemySettings EnemySett;		// used to reference Enemy variables
	public int CheckPoints;					// max checkpoints
	private int CurrentCheckPoint = 0;		
	private Vector3[] PlayerSPTransform;
	private int NumberOfPlayers;
	private int NumberOfEnemies;


	// Use this for initialization
	void Start () 
	{
		cam = gameObject.GetComponentInParent<CameraActor>();
		PlayerSett = gameObject.GetComponent<PlayerSettings>();
//		EnemySett = gameObject.GetComponent<EnemySettings>();

		NumberOfPlayers = 0;
		if (PlayerSpawnPoints == null) PlayerSpawnPoints = GameObject.FindGameObjectsWithTag("PlayerSpawn");
		PlayerSPTransform = new Vector3[(int)PlayerSett.Players];
		for(int i = 0; i < PlayerSpawnPoints.Length; i++)
		{
			getCurrentSpawns(i);
		}

		// spawn a Player for each spawn point for a player
		for(int i = 0; i < NumberOfPlayers; i++)
		{
			int typ = (int)PlayerSett.Data[i].PlayerType - 1;
			Vector3 pos = PlayerSPTransform[i];
			Vector3 rot = PlayerSpawnPoints[i].transform.rotation.eulerAngles;
			SpawnPlayer(pos, rot, typ, i);
		}

		NumberOfEnemies = 0;
		if (EnemySpawnPoints == null) EnemySpawnPoints = GameObject.FindGameObjectsWithTag("EnemySpawn");
		currentEnemy = new GameObject[EnemySpawnPoints.Length];
		currentEnemyUI = new GameObject[currentEnemy.Length];
		nme = new EnemyActor[currentEnemy.Length];
		for(int i = 0; i < EnemySpawnPoints.Length; i++)
		{
			int typ = (int)EnemySpawnPoints[i].GetComponent<EnemySpawner>().EnemyType - 1;
			Vector3 pos = EnemySpawnPoints[i].transform.position;
			Vector3 rot = EnemySpawnPoints[i].transform.rotation.eulerAngles;
			SpawnEnemy(pos, rot, typ, i);
			NumberOfEnemies++;
		}

	}

	// Spawn Player
	private void SpawnPlayer(Vector3 spawnPos, Vector3 spawnRot, int typ, int num)
	{
		currentPlayer = Instantiate(Prefabs[typ], spawnPos, Quaternion.Euler(spawnRot)) as GameObject;
		currentPlayer.tag = "Player";
		currentPlayer.AddComponent<PlayerActor>();

		cam.SetTarget(currentPlayer.transform);
	}
	private void SpawnEnemy(Vector3 spawnPos, Vector3 spawnRot, int typ, int num)
	{
		// Spawn Enemy at given Spawn Point facing direction of Spawnpoint
		currentEnemy[num] = Instantiate(Prefabs[typ], spawnPos, Quaternion.Euler(spawnRot)) as GameObject;
		currentEnemy[num].tag = "Enemy";
		currentEnemyUI[num] = Instantiate(EnemyUI, spawnPos, Quaternion.identity) as GameObject;
		currentEnemyUI[num].transform.SetParent(currentEnemy[num].transform);
		if(typ != 0) currentEnemyUI[num].transform.position += new Vector3(0,0.4f,0);
		else currentEnemyUI[num].transform.position += new Vector3(0,0.25f,0);
		currentEnemy[num].AddComponent<EnemyActor>();
		nme[num] = currentEnemy[num].GetComponent<EnemyActor>();
		nme[num].SetTarget(currentPlayer.transform);
		nme[num].type = typ;
	}
	private void getCurrentSpawns(int i)
	{
		if(PlayerSpawnPoints[i].GetComponent<BoxGizmos>().ActiveCheckpoint == CurrentCheckPoint)
		{
			PlayerSPTransform[NumberOfPlayers] = PlayerSpawnPoints[i].transform.position;
			NumberOfPlayers++;
		}
	}
	
	private void update() {
		// Player only spawns when there is no player
		if (currentPlayer == null)
		{
			if (Input.GetButtonDown("Respawn"))
			{
				for(int i = 0; i < NumberOfPlayers; i++)
				{
					int typ = (int)PlayerSett.Data[i].PlayerType - 1;
					Vector3 pos = PlayerSPTransform[i];
					Vector3 rot = PlayerSpawnPoints[i].transform.rotation.eulerAngles;
					SpawnPlayer(pos, rot, typ, i);
				}
			}
		}
	}

//	public void SetCheckpoint(int cp) 
//	{
//		CurrentCheckPoint = cp;
//	}
}
