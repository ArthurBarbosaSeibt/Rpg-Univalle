using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerClaytinho : MonoBehaviour {

	static public bool claytinho;

	void OnTriggerStay2D () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			claytinho = true;
			print ("foi");
		}
	}

	void OnTriggerExit2D () {
		claytinho = false;
		print ("desfoi");
	}
}
