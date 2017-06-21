using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrueAdorno : MonoBehaviour {

	public GameObject blockAdornos;
	
	void OnTriggerStay2D () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			blockAdornos.SetActive (false);
			print ("foi");
			//NPCblock.SetActive (false);
		}
	}
}
