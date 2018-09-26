using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class HumanControls : MonoBehaviour {

	public float maxTorque;
	private string controls;

	public string GetControlVals() {
		return controls;
	}

	void FixedUpdate() {
		Dictionary<string,float> controlsDict = new Dictionary<string,float>();
		controlsDict.Add("leftTorque", Input.GetAxis("LeftWheel")*maxTorque);
		controlsDict.Add("rightTorque", Input.GetAxis("RightWheel")*maxTorque);

		controls = JsonConvert.SerializeObject(controlsDict);
	}
}
