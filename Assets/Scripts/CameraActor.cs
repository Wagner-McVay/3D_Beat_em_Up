using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraActor : MonoBehaviour {

	public Transform target;

	public void SetTarget(Transform t){
		target = t;
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
	if (target != null)
		{
		Vector3 finalTargetPosition = transform.position;

		if (target.position.x > transform.position.x + 1) {
			finalTargetPosition.x += (target.position.x - (transform.position.x + 1));
		}
		if (target.position.x < transform.position.x - 1) {
			finalTargetPosition.x += (target.position.x - (transform.position.x - 1));
		}

		this.transform.position = new Vector3 (finalTargetPosition.x, transform.position.y, transform.position.z);
		}
	}
}


//	private Transform target;
//	private float trackSpeed = 10;
//
//	public void SetTarget(Transform t){
//		target = t;
//	}
//
//	void LateUpdate(){
//		if (target){
//
//			float x = IncrementTowards(transform.position.x, target.position.x, trackSpeed);
//			float y = IncrementTowards(transform.position.y, target.position.y, trackSpeed);
//			transform.position = new Vector3(x,y, transform.position.z);
//		}
//	}
//
//	// Increase n twards target by speed
//	private float IncrimentTwards(float n, float target, float a)
//	{
//		if (n == target)
//		{
//			return n;
//		}
//		else
//		{
//			float dir = Mathf.Sign(target - n); // must n be increased or decreased to get closer to target
//			n += a * Time.deltaTime * dir;
//			return (dir == Mathf.Sign(target - n)) ? n : target; // if n has now passed target then return target, otherwise return n
//		}
//	}