using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    public Text statusText;
    public Text player1Text;
    public Text player2Text;
	public Button poder1;
	public Button poder2;
	public Button poder3;
	public Button poder4;

    public GameObject battle;

    int player1Health = 100;
    int player2Health = 100;
    int mana = 100;

	private bool curar = false;
	private bool helloworld = false;
	private bool passar = false;
	private bool atacar = false;

    bool player1Turn = true;



    // Use this for initialization
    void Start()
	{
		Time.timeScale = 1;
        player1Health = 100;
        player2Health = 100;
        mana = 100;
        player1Text.text = "Vida: " + player1Health + " Mana: " + mana;
        StartPlayer1Turn();

    }

    // Update is called once per frame
    void Update()
    {
		player1Text.text = "Vida: " + player1Health + " Mana: " + mana ;
		player2Text.text = "Vida: " + player2Health;

		if (player2Health <= 0)
		{
			desabilitarBotoes ();
			player2Health = 0;
			statusText.text = " Você VENCEU!";
			Time.timeScale = 0;

		}

		if (player1Health < 1)
        {
			desabilitarBotoes ();
            player1Health = 0;
            statusText.text = " Você PERDEU!";
            Time.timeScale = 0;

        }
			
        //if (player1Health > 0 && player1Turn && Input.anyKey)
        //{
        //   Player1Fight();
        //  SwitchPlayers();


        // } 
    }

    void Player1Fight()
    {
		Animator playerAnim = GameObject.FindGameObjectWithTag ("battlePlayer").GetComponent<Animator>();

		playerAnim.SetBool ("atacar", true);
		atacar = true;

        if (player2Health <= 0)
        {
            player2Health = 0;
        }
        if (player2Health <= 0)
        {
            player2Health = 0;
            statusText.text = " Você VENCEU!";
            Time.timeScale = 0;

        }

    }

    void Player1FightCritico()
    {
		Animator playerAnim = GameObject.FindGameObjectWithTag ("battlePlayer").GetComponent<Animator>();

		playerAnim.SetBool ("hello", true);
		helloworld = true;
       
        if (player2Health <= 0)
        {
            player2Health = 0;
            statusText.text = " Você VENCEU!";
            Time.timeScale = 0;

        }

    }

	public void PassarTurno()
	{
		desabilitarBotoes ();
		StartCoroutine (passarTime ());
		SwitchPlayers();
	}
    
	IEnumerator passarTime(){
		Animator playerAnim = GameObject.FindGameObjectWithTag ("battlePlayer").GetComponent<Animator>();
		playerAnim.SetBool ("passar", true);
		passar = true;
		yield return new WaitForSeconds (2f);
		playerAnim.SetBool ("passar", false);
		passar = false;
		habilitarBotoes ();
	}

	void Player1cura()
    {
		Animator playerAnim = GameObject.FindGameObjectWithTag ("battlePlayer").GetComponent<Animator>();
		playerAnim.SetBool ("hamburgao", true);
		curar = true;
    }

    void SwitchPlayers()
	{
        player1Turn = !player1Turn;

        if (player1Turn && player1Health > 0)
        {
            StartPlayer1Turn();

        }
        else if (player2Health > 0)
        {
            StartPlayer2Turn();
        }
    }

    void StartPlayer1Turn()
    {
        Time.timeScale = 1;
        statusText.text = " Seu turno, escolha uma opção !";

    }

    void StartPlayer2Turn()
    {
        StartCoroutine(Player2Turn());

    }

    IEnumerator Player2Turn()
    {
		if (curar == true) {
			Animator playerAnim = GameObject.FindGameObjectWithTag ("battlePlayer").GetComponent<Animator> ();
			statusText.text = " Você comeu um Hamburgão duplo";
			yield return new WaitForSeconds (2f);
			playerAnim.SetBool ("hamburgao", false);

			int cura = Random.Range(25, 50);
			player1Health += cura;

			yield return new WaitForSeconds (1f);
			curar = false;
		}

		if (helloworld == true) {
			Animator playerAnim = GameObject.FindGameObjectWithTag ("battlePlayer").GetComponent<Animator> ();
			statusText.text = " Você programou o Hello World";
			yield return new WaitForSeconds (5.30f);
			playerAnim.SetBool ("hello", false);

			int damage = Random.Range(50, 50);
			player2Health -= damage;

			yield return new WaitForSeconds (0.4f);
			helloworld = false;
		}

		if (atacar == true) {
			Animator playerAnim = GameObject.FindGameObjectWithTag ("battlePlayer").GetComponent<Animator> ();
			statusText.text = " Você atacou!";
			yield return new WaitForSeconds (1.40f);
			playerAnim.SetBool ("atacar", false);

			int damage = Random.Range(25, 35);
			player2Health -= damage;

			yield return new WaitForSeconds (1f);
			atacar = false;
		}


		statusText.text = " Turno do oponente... Espere";
		yield return new WaitForSeconds(Random.Range(2, 2));

        if (player2Health >= 65)
        {
        Player2Fight();
        }

        if (player2Health < 65 && player2Health > 30)
        {
            Player2FightCritico();
        }

        if (player2Health <= 30)
        {           
        int cura = Random.Range(35, 50);
        player2Health += cura;  
        }


        SwitchPlayers();

    }

    void Player2Fight()
    {
        int damage = Random.Range(30, 36);
        player1Health -= damage;
        if (player1Health <= 0)
        {
            player1Health = 0;
        }

        if (player1Health <= 0)
        {
            player1Health = 0;
            statusText.text = "Você PERDEU";
            Time.timeScale = 0;
        }
    }

    void Player2FightCritico()
    {
        int damage = Random.Range(50, 50);
        player1Health -= damage;
      if (player1Health <= 0)
        {
            player1Health = 0;
        }

        if (player1Health <= 0)
        {
            player1Health = 0;
            statusText.text = "Você PERDEU";
            Time.timeScale = 0;
        }
    }

	void habilitarBotoes(){
		poder1.interactable = true;
		poder2.interactable = true;
		poder3.interactable = true;
		poder4.interactable = true;
	}

	void desabilitarBotoes(){
		poder1.interactable = false;
		poder2.interactable = false;
		poder3.interactable = false;
		poder4.interactable = false;
	}

    private void OnEnable()
    {
		habilitarBotoes ();
		Time.timeScale = 1;
        player1Turn = true;
        StartPlayer1Turn();
    }

    private void OnDisable()
    {
        player1Turn = true;
        player1Health = 100;
        player2Health = 100;
        player1Text.text = "Vida: " + player1Health + " Mana: " + mana;
        player2Text.text = "Vida: " + player2Health;
    }

    public void atkBasico()
    {
        if (player1Health > 0 && player1Turn)
        {
            Player1Fight();
            SwitchPlayers();
        }
        
    }
    public void Critico()
    {
        if (player1Health > 0 && player1Turn && mana >= 25)
        {
            mana -= 25;
            Player1FightCritico();
            SwitchPlayers();
        }
        else
        {
            statusText.text = "Você NÃO tem mana suficiente";
        }
    }

    public void Cura()
    {
        if (player1Health > 0 && player1Turn && mana >= 25)
        {
            mana -= 25;
            Player1cura();
            SwitchPlayers();
        }
        else
        {
            statusText.text = "Você NÃO tem mana suficiente";
        }
    }

//    public void PassarTurno()
//    {
//        if (player1Health > 0 && player1Turn)
//        {
//			Animator playerAnim = GameObject.FindGameObjectWithTag ("battlePlayer").GetComponent<Animator>();
//			playerAnim.SetBool ("passar", true);
//			passar = true;
//            SwitchPlayers();
//
//
//        }
//    }


}




