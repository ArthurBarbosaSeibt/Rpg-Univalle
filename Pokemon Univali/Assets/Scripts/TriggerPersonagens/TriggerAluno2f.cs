using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAluno2f : MonoBehaviour {

	static public bool aluno2f;

	void OnTriggerEnter2D () {
		aluno2f = true;
		print ("foi");
	}

	void OnTriggerExit2D () {
		aluno2f = false;
		print ("desfoi");
	}
}
