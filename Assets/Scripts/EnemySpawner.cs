using UnityEngine;
using System.Collections;

[RequireComponent (typeof (BoxCollider))]
public class EnemySpawner: MonoBehaviour {
	
	public int ActiveCheckpoint;
	
	public enum type:int {Wolf = 1,Android = 2,Mage = 3,Mantis = 4};
	public type EnemyType;
	
	public Color gizmoColor;
	void OnDrawGizmos() {
		Gizmos.color = gizmoColor;
		Gizmos.DrawCube(transform.position + GetComponent<BoxCollider>().center,GetComponent<BoxCollider>().size);
	}
}