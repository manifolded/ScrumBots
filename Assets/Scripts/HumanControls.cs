using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class HumanControls : IControls {

	private float maxTorque;
	private string controlsJson;

	public HumanControls(float _maxTorque) {
		maxTorque = _maxTorque;
	}

	public string GetControlData() {
		update();
		return controlsJson;
	}

	public void PutSensorData(string _sensorDataJson) {}

	void update() {
		Dictionary<string,float> controlsDict = new Dictionary<string,float>();
		controlsDict.Add("leftTorque", Input.GetAxis("LeftWheel")*maxTorque);
		controlsDict.Add("rightTorque", Input.GetAxis("RightWheel")*maxTorque);

		controlsJson = JsonConvert.SerializeObject(controlsDict);
	}
}
