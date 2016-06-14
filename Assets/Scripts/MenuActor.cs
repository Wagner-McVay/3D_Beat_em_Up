using UnityEngine;
using System.Collections;

public class MenuActor : MonoBehaviour {

	public void LoadLevel(string level_name)	{
		Application.LoadLevel (level_name);
	}

	public void Quit()	{
		Application.Quit();
	}
}
