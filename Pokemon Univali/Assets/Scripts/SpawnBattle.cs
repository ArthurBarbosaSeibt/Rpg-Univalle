using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBattle : MonoBehaviour {
	public GameObject batalha;
	public GameObject gatilhoParaBatalha;
	private int random;
	public bool infinito = false;

	//Concertar amanhã!!
	IEnumerator OnTriggerEnter2D (Collider2D other){		
		print ("voce entrou!");
		infinito = true;
		while (infinito == true) { 
			if (infinito == false) {
				break;
			}
			yield return new WaitForSeconds (0.5f);
			random = Random.Range (0, 100);
			if (random <= 5) {
				gatilhoParaBatalha.GetComponent<GatilhoCompartilhado> ().falaTrigger = true; //jogador fica parado

				// transição para batalha
				ScreenFader sf = GameObject.FindGameObjectWithTag ("Fader").GetComponent<ScreenFader> ();

				yield return StartCoroutine (sf.FadeToBlack ());

				batalha.SetActive (true);
				gatilhoParaBatalha.GetComponent<GatilhoCompartilhado> ().battleTrigger = true;

				yield return StartCoroutine (sf.FadeToClear ());

				while (gatilhoParaBatalha.GetComponent<GatilhoCompartilhado> ().fechou == false) {
					yield return new WaitForSeconds (0.5f);
				}
			}
		}
	}

	void OnTriggerExit2D (Collider2D other){		
		infinito = false; 
		print ("voce saiu!");	
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
