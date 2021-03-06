﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour {

	public GameObject tutorial;
	public GameObject napoleao;
	public GameObject claytinho;
	public GameObject aluno2f;
	public GameObject adorno;

	// Update is called once per frame
	void Update () {
		if (TriggerTutorial.tutorial == true) {
			tutorial.SetActive (true);
		} else {
			StartCoroutine (tutorialClose ());
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

		if (TriggerAdorno.adorno == true) {
			adorno.SetActive (true);
		} else {
			adorno.SetActive (false);
		}
	}

	IEnumerator tutorialClose(){
		yield return new WaitForSeconds (3.5f);
		tutorial.SetActive (false);
	}
}