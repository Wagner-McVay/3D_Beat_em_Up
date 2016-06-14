using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GameActor : MonoBehaviour {
	private GameObject Player;
	private GameObject[] enemies;
	private PlayerSettings PlayerSett;
	private EnemySettings EnemySett;
	private GameObject[] EnemySpawn;
	private GameObject PauseMenu;
	private GameObject StatBox;
	private GameObject[] EnemyHPBars;
	private bool Paused = false;
	private Text P_Name;
	private Text P_HPVal;
	private Text P_MPVal;
	private Slider P_HP;
	private Slider P_MP;
	private Slider[] E_HP;
	public float Hazard_Damage = 1;
	public float Hazard_Delay = 0.2f;
	private int Players;

	public void Restart() 
	{
		Application.LoadLevel(Application.loadedLevel);
	}

	public void LoadLevel(string level_name)	{
		Application.LoadLevel (level_name);
	}

	public void Resume()	{
		Paused = !Paused;
		Time.timeScale = 1;
		ToggleCanvas (false);
	}

	public void Quit()	{
		Application.Quit();
	}
	
	// Use this for initialization
	void Start () {
		PlayerSett = gameObject.GetComponentInChildren<PlayerSettings>();
		EnemySett = gameObject.GetComponentInChildren<EnemySettings>();
		EnemySpawn = GameObject.FindGameObjectsWithTag("EnemySpawn");

		PauseMenu = GameObject.Find("Pause_Menu");
		StatBox = GameObject.Find("StatBox");
		Players = (int)PlayerSett.Players;

		P_Name = GameObject.FindGameObjectWithTag("PlayerName").GetComponent<Text>();
		P_HPVal = GameObject.FindGameObjectWithTag("PlayerHP").GetComponentInChildren<Text>();
		P_MPVal = GameObject.FindGameObjectWithTag("PlayerMP").GetComponentInChildren<Text>();
		P_HP = GameObject.FindGameObjectWithTag("PlayerHP").GetComponent<Slider>();
		P_MP = GameObject.FindGameObjectWithTag("PlayerMP").GetComponent<Slider>();
		P_HP.maxValue = PlayerSett.Data[0].PlayerHP;
		P_MP.maxValue = PlayerSett.Data[0].PlayerMP;
		P_Name.text = PlayerSett.Data[0].PlayerName;
		P_HPVal.text = P_HP.value.ToString();
		P_MPVal.text = P_MP.value.ToString();

		if (EnemyHPBars == null) EnemyHPBars = GameObject.FindGameObjectsWithTag("EnemyHP");
		if (EnemyHPBars != null) 
		
			E_HP = new Slider[EnemyHPBars.Length];
			for(int i = 0; i < EnemyHPBars.Length; i++)
			{
				int typ = (int)EnemySpawn[i].GetComponent<EnemySpawner>().EnemyType -1;
				E_HP[i] = EnemyHPBars[i].GetComponent<Slider>();
				E_HP[i].maxValue = EnemySett.EnemyTypes[typ].EnemyHP;
			}


		// turn UI objects off
		PauseMenu.SetActive (false);
		StatBox.SetActive (false);
		Paused = false;

		// turn Player UI objects on if Players >= 1
		StatBox.SetActive (true);
		if (Time.timeScale == 0) Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (Player == null) 
		
			Player = GameObject.FindGameObjectWithTag("Player");
			for(int plr = 0; plr < Players; plr++)
			{
				if (Player != null) P_HP.value = Player.GetComponent<PlayerActor>().getHP();
				P_HPVal.text = P_HP.value.ToString();
				if (Player != null) P_MP.value = Player.GetComponent<PlayerActor>().getMP();
				P_MPVal.text = P_MP.value.ToString();
			}


		if (enemies == null)
		
			enemies = GameObject.FindGameObjectsWithTag("Enemy");
			for(int nme = 0; nme < E_HP.Length; nme++)
			{
				if (enemies[nme] != null) E_HP[nme].value = enemies[nme].GetComponent<EnemyActor>().getHP();
			}

		// pause if Esc is pressed
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			Paused = !Paused;
			// transition to...
			
			// pause
			if (Paused){
				Time.timeScale = 0;
				ToggleCanvas (true);
			}
			// unpaused
			else
			{
				Time.timeScale = 1;
				ToggleCanvas (false);
			}
		}
	}

	void ToggleCanvas(bool X) {
		PauseMenu.SetActive(X);
	}
}
