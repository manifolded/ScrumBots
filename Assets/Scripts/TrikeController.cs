using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrikeController : MonoBehaviour {

    public List<WheelCollider> wheelColliders;
    public List<float> torques;
    public float maxTorque;

    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        // This code makes the assumption that the visual wheel is a child of the wheel collider.
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
        float[] vals = {Input.GetAxis("LeftWheel")*maxTorque, Input.GetAxis("RightWheel")*maxTorque}; 
        List<float> controls = new List<float>(vals);

        for(int i = 0; i<wheelColliders.Count; i++) {
            wheelColliders[i].motorTorque = controls[i];
            ApplyLocalPositionToVisuals(wheelColliders[i]);
		}
	}
}
