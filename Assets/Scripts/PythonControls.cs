using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IronPython;
using IronPython.Modules;
using IronPython.Hosting;
using Newtonsoft.Json;

public class PythonControls : IControls {

	private string commandsJson;
	private dynamic engine;
	private dynamic scope;

	public PythonControls(float _maxTorque, string _path) {
		engine = Python.CreateEngine();
		scope = engine.CreateScope();
		scope.SetVariable("maxTorque", _maxTorque);
		engine.ExecuteFile(_path, scope);
	}

	public string GetControlData() {
		return scope.GetVariable<string>("commands");
	}

	public void PutSensorData(string _sensorDataJson) {
		scope.SetVariable("sensorDataJson", _sensorDataJson);
	}
}
