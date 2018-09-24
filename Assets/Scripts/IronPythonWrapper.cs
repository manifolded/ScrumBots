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
		// create the engine
		var engine = IronPython.Hosting.Python.CreateEngine();

		// and the scope (i.e. the Python namespace)
		var scope = engine.CreateScope();

		// execute a string in the interpreter and grab the variable
		string example = "output = 'hello world'";

		engine.CreateScriptSourceFromString(example).Execute(scope);
		string came_from_script = scope.GetVariable<string>("output");

		// Should be what we put into 'output' in the script.
		Debug.Log(came_from_script);
	}
}
