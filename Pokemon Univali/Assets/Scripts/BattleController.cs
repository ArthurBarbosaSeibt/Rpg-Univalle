using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour {
    public Text statusText;
    public Text player1Text;
    public Text player2Text;
	public GameObject battle;

    int player1Health = 100;
    int player2Health = 100;
	int mana = 100;

    bool player1Turn = true;



	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        player1Health = 100;
        player2Health = 100;
		mana = 100;

        StartPlayer1Turn();

	}
	
	// Update is called once per frame
	void Update ()
    {
        if(player1Health < 1)
        {
			player1Health = 0;
			statusText.text = " Você PERDEU!";
            Time.timeScale = 0;

        }

		if (player1Health > 0 && player1Turn && Input.anyKey)
        {
            Player1Fight();
            SwitchPlayers();


        } 
	}

	void Player1Fight()
	{
		int damage = Random.Range(25, 35);
		player2Health -= damage;
		if (player2Health - damage == 0) {
			player2Health = 0;
		}
		if (player2Health <= 0)
		{
			player2Health = 0;
			statusText.text = " Você VENCEU!";
			Time.timeScale = 0;

		}

	}

	void SwitchPlayers()
	{
		player1Text.text = "Vida: " + player1Health;
		player2Text.text = "Vida: " + player2Health;
		player1Turn = !player1Turn;

		if (player1Turn && player1Health > 0)
		{
			StartPlayer1Turn();

		} else if (player2Health > 0){
			StartPlayer2Turn();
		}
	}

	void StartPlayer1Turn()
    {
        Time.timeScale = 1;
        statusText.text = " Aperte qualquer tecla para atacar! ";

    }

    void StartPlayer2Turn()
    {
        statusText.text = " Turno do oponente ...";
        StartCoroutine(Player2Turn());

    }
    
	IEnumerator Player2Turn()
    {
        yield return new WaitForSeconds(Random.Range(2, 2));
        Player2Fight();
        SwitchPlayers();

    }

	void Player2Fight()
    {
        int damage = Random.Range(30, 36);
        player1Health -= damage;
		if (player1Health - damage == 0) {
			player1Health = 0;
		}

        if (player1Health <= 0)
        {
			player1Health = 0;
			statusText.text = "Você PERDEU";
            Time.timeScale = 0;
        }
    }

    private void OnEnable()
    {
        Time.timeScale = 1;
        player1Turn = true;
        StartPlayer1Turn();
    }

    private void OnDisable()
    {
        player1Turn = true;
        player1Health = 100;
        player2Health = 100;
        player1Text.text = "Vida: " + player1Health;
        player2Text.text = "Vida: " + player2Health;    
    }

//	public void atkBasico(){
//		if (player1Turn == true) {	
//			int damage = Random.Range (20, 30);
//			player2Health -= damage;
//			statusText.text = "Você deu um ataque básico <br> e deu " + damage + " de dano!";
//			Time.timeScale = 0;
//			if (Input.anyKey) {
//				Time.timeScale = 1;
//			}
//
//			if (player2Health - damage == 0) {
//				player2Health = 0;
//			}
//			if (player2Health <= 0) {
//				player2Health = 0;
//				statusText.text = " Você VENCEU!";
//				Time.timeScale = 0;
//			}
//		}
//	}
//
//	void atkFoda(){
//		if (player1Turn == true) {
//			int damage = Random.Range (20, 30) * 2;
//			player2Health -= damage;
//			mana -= 20;
//
//			if (player2Health - damage == 0) {
//				player2Health = 0;
//			}
//			if (player2Health <= 0) {
//				player2Health = 0;
//				statusText.text = " Você VENCEU!";
//				Time.timeScale = 0;
//			}
//		}
//	}

}
