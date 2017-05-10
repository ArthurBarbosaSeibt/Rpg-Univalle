using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNapoleao : MonoBehaviour {

	static public bool napoleao;
	//public GameObject NPCblock;

	void OnTriggerStay2D () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			napoleao = true;
			print ("foi");
			//NPCblock.SetActive (false);
		}
	}

	void OnTriggerExit2D () {
		napoleao = false;
		print ("desfoi");
	}
}
