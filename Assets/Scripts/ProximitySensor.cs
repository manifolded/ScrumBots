using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximitySensor : MonoBehaviour, ISensor {

	private const float maxRange = 200.0f;
	private LayerMask mask;

	public float getSensorValue() {
		Vector3 forward = transform.TransformDirection(Vector3.up);

		RaycastHit hit;
		if(Physics.Raycast(transform.position, forward, out hit, maxRange, mask)) {
			Debug.DrawRay(transform.position, forward*hit.distance, Color.yellow);
			return hit.distance;
		} else {
			Debug.DrawRay(transform.position, forward*maxRange, Color.white);
			return maxRange;
		}
	}

	void Start() {
		// we want to ignore layer 2 which is titled "Ignore Raycast"
		mask = 2;
		mask = ~mask;
	}
}
