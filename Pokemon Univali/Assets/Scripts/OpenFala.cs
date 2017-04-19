using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OpenFala : MonoBehaviour {

	//public GameObject batalha;
	public GameObject gatilhoParaBatalha;
	public Text texto;
	public Canvas canvas; 
	public GameObject animacaoPassar;
	public bool terminoFala;
	private string dialogo;
	private string dialogoSave;
	private bool dialogo2 = false;
	private bool dialogo3 = false;
	private bool dialogo4 = false;
	private bool dialogo5 = false;
	private bool dialogo6 = false;
	private int i;
	private int j;
	public bool go = false;
	public bool stay = false;
	private float time1 = 3f;
	private float delay = 0;

// -------------------------------------------------------

//	private bool wait(float seconds){
//		timerMax = seconds;
//		timer += Time.deltaTime;
//
//		while (timer += Time.deltaTime) {
//		
//		}
//		return false;
//	}

	string Start(){
		dialogoSave = texto.text;
		return dialogoSave;
	}
		
	void OnTriggerExit2D (Collider2D other){
		//CanvasGroup espaco = GameObject.FindGameObjectWithTag ("pressSpace").GetComponent<CanvasGroup> ();
		//espaco.alpha = 0;
		Animator anim2 = GameObject.FindGameObjectWithTag ("pressSpace").GetComponent<Animator>();
		anim2.SetBool("estaAparecendo", false);
		stay = false;

	}

//	void OnTriggerEnter2D (Collider2D other){
//		Rigidbody2D player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ();
//		player.WakeUp();
//
//	}

	IEnumerator OnTriggerStay2D (Collider2D other)
	{		
		//CanvasGroup espaco = GameObject.FindGameObjectWithTag ("pressSpace").GetComponent<CanvasGroup> ();
		//espaco.alpha = 1;
		Animator anim2 = GameObject.FindGameObjectWithTag ("pressSpace").GetComponent<Animator> ();
		anim2.SetBool ("estaAparecendo", true);

		//Rigidbody2D player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ();
		//player.Sleep();

		if (Input.GetKeyDown (KeyCode.Space)) {

			Animator anim = animacaoPassar.GetComponent<Animator> ();
			gatilhoParaBatalha.GetComponent<GatilhoCompartilhado> ().falaTrigger = true;
			CanvasGroup fala = canvas.GetComponent<CanvasGroup> ();

			dialogo = texto.text;
			texto.text = "";

			fala.alpha = 1f;
			for (i = 0; i < dialogo.Length; i++) {
				//			if (Input.anyKey) {
				yield return new WaitForSeconds (0.02f);
				texto.text += dialogo [i];
				//			} else {
				//				yield return new WaitForSeconds (0.1f);
				//				texto.text += dialogo [i];
				//			} 

				if (i >= 100 && dialogo [i] == ' ' && dialogo2 == false) {
					anim.SetBool ("passando", true);
					for (int j = 0; j < 100; j++) { 
						yield return new WaitForSeconds (0.1f);
						if (Input.anyKey) {
							j = 100;
							anim.SetBool ("passando", false);
						}
					}
					anim.SetBool ("passando", false);
					texto.text = "";
					dialogo2 = true;
				}
				if (i >= 200 && dialogo [i] == ' ' && dialogo3 == false) {
					anim.SetBool ("passando", true);
					for (int j = 0; j < 100; j++) { 
						yield return new WaitForSeconds (0.1f);
						if (Input.anyKey) {
							j = 100;
							anim.SetBool ("passando", false);
						}
					}
					anim.SetBool ("passando", false);
					texto.text = "";
					dialogo3 = true;
				}
				if (i >= 300 && dialogo [i] == ' ' && dialogo4 == false) {
					anim.SetBool ("passando", true);
					for (int j = 0; j < 100; j++) { 
						yield return new WaitForSeconds (0.1f);
						if (Input.anyKey) {
							j = 100;
							anim.SetBool ("passando", false);
						}
					}
					anim.SetBool ("passando", false);
					texto.text = "";
					dialogo4 = true;
				}
				if (i >= 400 && dialogo [i] == ' ' && dialogo5 == false) {
					anim.SetBool ("passando", true);
					for (int j = 0; j < 100; j++) { 
						yield return new WaitForSeconds (0.1f);
						if (Input.anyKey) {
							j = 100;
							anim.SetBool ("passando", false);
						}
					}
					anim.SetBool ("passando", false);
					texto.text = "";
					dialogo5 = true;
				}
				if (i >= 500 && dialogo [i] == ' ' && dialogo6 == false) {
					anim.SetBool ("passando", true);
					for (int j = 0; j < 100; j++) { 
						yield return new WaitForSeconds (0.1f);
						if (Input.anyKey) {
							j = 100;
							anim.SetBool ("passando", false);
						}
					}
					anim.SetBool ("passando", false);
					texto.text = "";
					dialogo6 = true;
				}
			}
			anim.SetBool ("passando", true);
			for (int j = 0; j < 100; j++) { 
				yield return new WaitForSeconds (0.1f);
				if (Input.anyKey) {
					j = 100;
				}
			}

			anim.SetBool ("passando", false);
			fala.alpha = 0f;
			texto.text = dialogoSave;
			dialogo2 = false;
			dialogo3 = false;
			dialogo4 = false;
			dialogo5 = false;
			dialogo6 = false;
			gatilhoParaBatalha.GetComponent<GatilhoCompartilhado> ().falaTrigger = false; 
			//StopAllCoroutines ();
		}
	}
}


