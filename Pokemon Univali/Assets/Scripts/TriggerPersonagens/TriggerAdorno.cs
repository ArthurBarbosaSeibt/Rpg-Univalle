using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAdorno : MonoBehaviour {

	static public bool adorno;
	//public GameObject NPCblock;

	void OnTriggerStay2D () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			adorno = true;
			print ("foi");
			//NPCblock.SetActive (false);
		}
	}

	void OnTriggerExit2D () {
		adorno = false;
		print ("desfoi");
	}
}
