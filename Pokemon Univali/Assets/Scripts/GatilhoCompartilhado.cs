using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatilhoCompartilhado : MonoBehaviour {

	public bool battleTrigger;
	public bool falaTrigger;
	public GameObject battle;

	void Start(){
		falaTrigger = false;
		battleTrigger = false;
	}

	public void CloseBattle(){ //botão de sair do canvas da batalha ativa isso
		battleTrigger = false;
		falaTrigger = false;
		battle.SetActive(false);
        Time.timeScale = 1;
    }
}
