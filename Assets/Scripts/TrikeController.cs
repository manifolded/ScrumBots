using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class TrikeController : MonoBehaviour {

    public List<WheelCollider> wheelColliders;
    public List<float> torques;
    public float maxTorque;

    public IControls controller;

    public void ApplyLocalPositionToVisuals(WheelCollider collider) {
        // This code makes the assumption that the visual wheel is a child of the wheel collider.
        if (collider.transform.childCount == 0) {
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

    void Start() {
        controller = new HumanControls();
    }
    
    void FixedUpdate() {
        string controlsJson = controller.GetControlVals();
        // Debug.Log(controlsJson);

        Dictionary<string, float> controlsDict = 
            JsonConvert.DeserializeObject<Dictionary<string, float>>(controlsJson);

        wheelColliders[0].motorTorque = controlsDict["leftTorque"];
        ApplyLocalPositionToVisuals(wheelColliders[0]);
        wheelColliders[1].motorTorque = controlsDict["rightTorque"];
        ApplyLocalPositionToVisuals(wheelColliders[1]);
	}
}
