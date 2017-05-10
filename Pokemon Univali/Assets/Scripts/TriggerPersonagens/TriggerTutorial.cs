using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTutorial : MonoBehaviour {

	static public bool tutorial;

	void OnTriggerStay2D () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			tutorial = true;
			print ("foi");
		}
	}

	void OnTriggerExit2D () {
		tutorial = false;
		print ("desfoi");
	}
}
