using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour {

	public GameObject tutorial;
	public GameObject napoleao;
	public GameObject claytinho;
	public GameObject aluno2f;


	// Update is called once per frame
	void Update () {
		if (TriggerTutorial.tutorial == true) {
			tutorial.SetActive (true);
		} else {
			tutorial.SetActive (false);
		}

		if (TriggerNapoleao.napoleao == true) {
			napoleao.SetActive (true);
		} else {
			napoleao.SetActive (false);
		}

		if (TriggerClaytinho.claytinho == true) {
			claytinho.SetActive (true);
		} else {
			claytinho.SetActive (false);
		}

		if (TriggerAluno2f.aluno2f == true) {
			aluno2f.SetActive (true);
		} else {
			aluno2f.SetActive (false);
		}
	}
}
