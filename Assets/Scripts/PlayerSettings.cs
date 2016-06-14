using UnityEngine;
using System.Collections;

public class PlayerSettings : MonoBehaviour {

	public enum multiPlayer:int {One = 1,Two = 2,Three = 3,Four = 4}
	public multiPlayer Players;

	[System.Serializable]
	public class data
	{
		public enum playerType {Wolf = 1,Android = 2,Mage = 3,Mantis = 4}
		public playerType PlayerType;

		public string PlayerName;
		public float PlayerHP = 100;
		public float PlayerMP = 100;
		public float PlayerDamage = 5;
		public float PlayerArmor = 0;
		public float PlayerJump = 1;
		public float PlayerSpeed = 1;
		public float PlayerGravity = 1;
		public float RangeAttackSpeed = 1;
		public float RangeAttackDecay = 1;

	}
	public data[] Data;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}
}