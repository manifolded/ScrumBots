using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AxleInfo {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
	public float leftMotor;
	public float rightMotor;
}
public class RobotController : MonoBehaviour {
	public List<AxleInfo> axleInfos;

	public void ApplyLocalPositionToVisuals(WheelCollider collider) {
		if(collider.transform.childCount == 0) {
			return;
		}

		Transform visualWheel = collider.transform.GetChild(0);

		Vector3 position;
		Quaternion rotation;
		collider.GetWorldPose(out position, out rotation);

		visualWheel.transform.position = position;
		visualWheel.transform.rotation = rotation;
	}

	void FixedUpdate() {
		foreach(AxleInfo axleInfo in axleInfos) {
			axleInfo.leftWheel.motorTorque = axleInfo.leftMotor;
			ApplyLocalPositionToVisuals(axleInfo.leftWheel);
			axleInfo.rightWheel.motorTorque = axleInfo.rightMotor;
			ApplyLocalPositionToVisuals(axleInfo.rightWheel);
			
		}
	}
}
