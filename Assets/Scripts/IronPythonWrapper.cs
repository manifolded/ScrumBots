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
		var ScriptEngine = IronPython.Hosting.Python.CreateEngine();

		// and the scope (i.e. the Python namespace)
		var ScriptScope = ScriptEngine.CreateScope();

		// execute a string in the interpreter and grab the variable
		string example = "output = 'hello world'";

		ScriptEngine.CreateScriptSourceFromString(example).Execute(ScriptScope);
		string came_from_script = ScriptScope.GetVariable<string>("output");

		// Should be what we put into 'output' in the script.
		Debug.Log(came_from_script);
	}
}
