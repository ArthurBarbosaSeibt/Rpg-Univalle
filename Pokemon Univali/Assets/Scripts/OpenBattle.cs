using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OpenBattle : MonoBehaviour {

	public GameObject battle;
	public GameObject trigger;
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
// -------------------------------------------------------

	string Start(){
		Text texto = GameObject.FindGameObjectWithTag ("Fala").GetComponent<Text> ();
		dialogoSave = texto.text;
		return dialogoSave;

	}

	IEnumerator OnTriggerEnter2D (Collider2D other){		
		Animator anim = GameObject.FindGameObjectWithTag ("Passar").GetComponent<Animator> ();
		CanvasGroup fala = GameObject.FindGameObjectWithTag ("CanvasFala").GetComponent<CanvasGroup> ();
		//CanvasGroup passar = GameObject.FindGameObjectWithTag ("Passar").GetComponent<CanvasGroup> ();
		trigger.GetComponent<GatilhoCompartilhado> ().falaTrigger = true;

		Text texto = GameObject.FindGameObjectWithTag ("Fala").GetComponent<Text> ();

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

		ScreenFader sf = GameObject.FindGameObjectWithTag ("Fader").GetComponent<ScreenFader> ();

		yield return StartCoroutine (sf.FadeToBlack ());

		battle.SetActive(true);
		trigger.GetComponent<GatilhoCompartilhado> ().battleTrigger = true;

		yield return StartCoroutine (sf.FadeToClear ());
		}
}
