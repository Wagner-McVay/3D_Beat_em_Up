using UnityEngine;
using System.Collections;


public class MenuActor : MonoBehaviour {
	private GameObject PauseMenu;
	private GameObject P1;
	private GameObject P2;
	private GameObject P3;
	private GameObject P4;
	private bool Paused = false;
	public int Players = 1;

	public void LoadLevel(string level_name)	{
		Application.LoadLevel (level_name);
	}

	public void ResumeGame()	{
		Paused = !Paused;
	}

	public void ExitGame()	{
		Application.Quit();
	}
	
	// Use this for initialization
	void Start () {
		// define UI objects
		PauseMenu = GameObject.Find("Pause_Menu");
		P1 = GameObject.Find("P1_Box");
		P2 = GameObject.Find("P2_Box");
		P3 = GameObject.Find("P3_Box");
		P4 = GameObject.Find("P4_Box");
		// turn UI objects off
		PauseMenu.SetActive (false);
		P1.SetActive (false);
		P2.SetActive (false);
		P3.SetActive (false);
		P4.SetActive (false);
		Paused = false;
		// turn Player UI objects on if Players >= 1
		if (Players >= 1) P1.SetActive (true);
		if (Players >= 2) P2.SetActive (true);
		if (Players >= 3) P3.SetActive (true);
		if (Players >= 4) P4.SetActive (true);
		if (Time.timeScale == 0)
			Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
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
