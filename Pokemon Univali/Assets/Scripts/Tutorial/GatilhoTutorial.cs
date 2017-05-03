using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatilhoTutorial : MonoBehaviour {

	public bool battleTrigger;
	public bool falaTrigger;
	public GameObject battle;
	public GameObject spawnBattle;
	public bool fechou;

	void Start(){
		falaTrigger = false;
		battleTrigger = false;
	}

	public void CloseBattle(){ //botão de sair do canvas da batalha ativa isso
		battleTrigger = false;
		falaTrigger = false;
		battle.SetActive(false);
		fechou = true;

		Time.timeScale = 1;
	}
}
