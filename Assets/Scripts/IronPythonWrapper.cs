using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using IronPython;
using IronPython.Modules;
using System.Text;

public class IronPythonWrapper : MonoBehaviour {

	void Start() {
	//	Debug.Log("before fishheads");
		ScriptTest();
	}


	public static void ScriptTest() {
		// request debug mode
		Dictionary<string, object> options = new Dictionary<string, object>();
		options["Debug"] = true;

		// create the engine
		// var engine = IronPython.Hosting.Python.CreateEngine(options); // this generates a whole different set of horrible errors
		var engine = IronPython.Hosting.Python.CreateEngine();

		// and the scope (i.e. the Python namespace)
		var scope = engine.CreateScope();

		// execute the Python script
		engine.ExecuteFile("Assets/Scripts/robot.py");

		// What's happening is that robot.py is generating errors when executed, but we never see them?
		// How do we trap errors from the Python scripts?

		// grab the variable from the Python scope
		string commands = scope.GetVariable<string>("commands");

		// Should be what we put into 'output' in the script.
		Debug.Log(commands);
	}
}
