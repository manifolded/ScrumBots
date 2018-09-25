using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using IronPython;
using IronPython.Modules;
using System.Text;
using Newtonsoft.Json;

public class IronPythonWrapper : MonoBehaviour {

	public void Start() {
		// create the engine
		var engine = IronPython.Hosting.Python.CreateEngine();

		// and the scope (i.e. the Python namespace)
		var scope = engine.CreateScope();

		// execute the Python script
		engine.ExecuteFile("Assets/Scripts/robot.py", scope);

		// grab the variable from the Python scope
		dynamic commands = JsonConvert.DeserializeObject<Dictionary<string,float>>(scope.GetVariable<string>("commands"));
		
		float motorLeft = commands["motorLeft"];
		float motorRight = commands["motorRight"];

		Debug.Log(motorLeft);
		Debug.Log(motorRight);
	}
}
