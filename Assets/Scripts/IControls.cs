using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControls {

	string GetControlData();

	void PutSensorData(string _sensorDataJson);
}
