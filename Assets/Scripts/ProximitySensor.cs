using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximitySensor : MonoBehaviour, ISensor {

	private const float maxRange = 200.0f;

	public float getSensorValue() {
		Vector3 forward = transform.TransformDirection(Vector3.forward);

		RaycastHit hit;
		if(Physics.Raycast(transform.position, forward, out hit, maxRange)) {
			Debug.DrawRay(transform.position, forward*hit.distance, Color.yellow);
			return hit.distance;
		} else {
			Debug.DrawRay(transform.position, forward*maxRange, Color.red);
			return maxRange;
		}
	}
}
