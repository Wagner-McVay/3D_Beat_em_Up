using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemySettings: MonoBehaviour {

	public enum difficulty {Easy,Medium,Hard};
	public difficulty Difficulty;

	[System.Serializable]
	public class Data
	{
		public GameObject EnemyPrefab;
		public GameObject RangeAttackPrefab;
		public float EnemyHP = 100;
		public float EnemyMP = 100;
		public float EnemyDamage = 5;
		public float EnemyArmor = 0;
		public float EnemyJump = 1;
		public float EnemySpeed = 1;
		public float EnemyGravity = 1;
	}
	public Data[] EnemyTypes;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
