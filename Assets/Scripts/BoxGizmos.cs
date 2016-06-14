using UnityEngine;
using System.Collections;

[RequireComponent (typeof (BoxCollider))]
public class BoxGizmos : MonoBehaviour {

	public int ActiveCheckpoint;

	public enum type:int {Players = 1,Enemys = 2,Objects = 3};
	public type SpawnType;


//	private enum enemyType:int {Wolf = 1,Android = 2,Mage = 3,Mantis = 4};
//	private enemyType EnemyType;
//
//	void Start () 
//	{
//		if(SpawnType == type.Players)
//		{
//
//		}
//		if(SpawnType == type.Enemys)
//		{
//
//		}
//		if(SpawnType == type.Objects)
//		{
//			
//		}
//	}

	public Color gizmoColor;
	void OnDrawGizmos() {
		Gizmos.color = gizmoColor;
		Gizmos.DrawCube(transform.position + GetComponent<BoxCollider>().center,GetComponent<BoxCollider>().size);
	}


}
