using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AxleInfo {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public float speed;

    [HideInInspector]
    public float leftMotor;
    [HideInInspector]
    public float rightMotor;
}

public class RobotController : MonoBehaviour {
	public List<AxleInfo> axleInfos;

    private float leftMotorTorque;
    private float rightMotorTorque;


    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        rotation = Quaternion.Euler(rotation.eulerAngles.x, rotation.eulerAngles.y, rotation.eulerAngles.z - 90);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    void FixedUpdate() {

        foreach (AxleInfo axleInfo in axleInfos) {

            leftMotorTorque = Input.GetAxis("LeftWheel") * axleInfo.speed;
            rightMotorTorque = Input.GetAxis("RightWheel") * axleInfo.speed;

            axleInfo.leftWheel.motorTorque = leftMotorTorque;
			ApplyLocalPositionToVisuals(axleInfo.leftWheel);
			axleInfo.rightWheel.motorTorque = rightMotorTorque;
			ApplyLocalPositionToVisuals(axleInfo.rightWheel);
			
		}
	}
}
