using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraActor : MonoBehaviour {

	public Transform target;

	// Update is called once per frame
	void FixedUpdate () {

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
