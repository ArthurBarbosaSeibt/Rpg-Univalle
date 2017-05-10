using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleController : MonoBehaviour
{
    public Text statusText;
    public Text player1Text;
    public Text player2Text;
	public Button poder1;
	public Button poder2;
	public Button poder3;
	public Button poder4;

	public Button Sair;
    public GameObject battle;

	public GameObject blockNapoleao;

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
    void FixedUpdate()
    {
		player1Text.text = "Vida: " + player1Health + " Mana: " + mana ;
		player2Text.text = "Vida: " + player2Health;

		if (player2Health <= 0){
			desabilitarBotoes ();
			player2Health = 0;
			statusText.text = " Você VENCEU!";
			if (TriggerNapoleao.napoleao == true){
				blockNapoleao.SetActive(false);
			}
			Sair.interactable = true;
			Time.timeScale = 0;
		}

		if (player1Health < 1){
			statusText.text = " Você PERDEU!";
			desabilitarBotoes ();
            player1Health = 0;
			StartCoroutine(gameover());
        }
    }

	IEnumerator gameover(){
		yield return new WaitForSeconds (4f);
		desabilitarNPCs ();
		Application.LoadLevel("gameover");
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
			//fim da animação da skill, o início está na função do botão
			statusText.text = " Você programou o Hello World";
			yield return new WaitForSeconds (5.30f);
			playerAnim.SetBool ("hello", false);

			int damage = Random.Range(50, 50);

			//gambiarra
			if (TriggerTutorial.tutorial == true){
				Animator NPCAnim = GameObject.FindGameObjectWithTag ("battleCherobin").GetComponent<Animator> ();
				NPCAnim.SetBool ("tomarDano", true);
				yield return new WaitForSeconds (0.5f);
				NPCAnim.SetBool ("tomarDano", false);
			}
			if (TriggerNapoleao.napoleao == true){
				Animator NPCAnim = GameObject.FindGameObjectWithTag ("battleNapoleao").GetComponent<Animator> ();
				NPCAnim.SetBool ("tomarDano", true);
				yield return new WaitForSeconds (0.5f);
				NPCAnim.SetBool ("tomarDano", false);
			}
			if (TriggerClaytinho.claytinho == true){
				Animator NPCAnim = GameObject.FindGameObjectWithTag ("battleClaytinho").GetComponent<Animator> ();
				NPCAnim.SetBool ("tomarDano", true);
				yield return new WaitForSeconds (0.5f);
				NPCAnim.SetBool ("tomarDano", false);
			}
			if (TriggerAluno2f.aluno2f == true){
				Animator NPCAnim = GameObject.FindGameObjectWithTag ("battleAlunoSpawn2f").GetComponent<Animator> ();
				NPCAnim.SetBool ("tomarDano", true);
				yield return new WaitForSeconds (0.5f);
				NPCAnim.SetBool ("tomarDano", false);
			}
			//fim da gambiarra

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

			//gambiarra
			if (TriggerTutorial.tutorial == true){
				Animator NPCAnim = GameObject.FindGameObjectWithTag ("battleCherobin").GetComponent<Animator> ();
				NPCAnim.SetBool ("tomarDano", true);
				yield return new WaitForSeconds (0.5f);
				NPCAnim.SetBool ("tomarDano", false);
			}
			if (TriggerNapoleao.napoleao == true){
				Animator NPCAnim = GameObject.FindGameObjectWithTag ("battleNapoleao").GetComponent<Animator> ();
				NPCAnim.SetBool ("tomarDano", true);
				yield return new WaitForSeconds (0.5f);
				NPCAnim.SetBool ("tomarDano", false);
			}
			if (TriggerClaytinho.claytinho == true){
				Animator NPCAnim = GameObject.FindGameObjectWithTag ("battleClaytinho").GetComponent<Animator> ();
				NPCAnim.SetBool ("tomarDano", true);
				yield return new WaitForSeconds (0.5f);
				NPCAnim.SetBool ("tomarDano", false);
			}
			if (TriggerAluno2f.aluno2f == true){
				Animator NPCAnim = GameObject.FindGameObjectWithTag ("battleAlunoSpawn2f").GetComponent<Animator> ();
				NPCAnim.SetBool ("tomarDano", true);
				yield return new WaitForSeconds (0.5f);
				NPCAnim.SetBool ("tomarDano", false);
			}
			//fim da gambiarra

			player2Health -= damage;
			yield return new WaitForSeconds (1f);
			atacar = false;
		}

		statusText.text = " Turno do oponente... Espere";
		desabilitarBotoes ();
		yield return new WaitForSeconds(2f);

        if (player2Health >= 65){
			statusText.text = " Oponente atacou normalmente!";
			yield return new WaitForSeconds(2.5f);

			int damage = Random.Range(30, 36);
			player1Health -= damage;

			// animação do player tomando dano
			Animator playerAnim = GameObject.FindGameObjectWithTag ("battlePlayer").GetComponent<Animator> ();
			playerAnim.SetBool ("tomarDano", true);
			yield return new WaitForSeconds (0.5f);
			playerAnim.SetBool ("tomarDano", false);
        }

        if (player2Health < 65 && player2Health > 30)
        {
			statusText.text = " Oponente deu um super ataque";
			yield return new WaitForSeconds(2.5f);

			int damage = Random.Range(50, 50);
			player1Health -= damage;

			// animação do player tomando dano
			Animator playerAnim = GameObject.FindGameObjectWithTag ("battlePlayer").GetComponent<Animator> ();
			playerAnim.SetBool ("tomarDano", true);
			yield return new WaitForSeconds (0.5f);
			playerAnim.SetBool ("tomarDano", false);

        }

        if (player2Health <= 30){
			statusText.text = " Oponente se curou!";
			yield return new WaitForSeconds(2.5f);	
        	int cura = Random.Range(35, 50);
        	player2Health += cura;  
        }

		habilitarBotoes();
        SwitchPlayers();

    }

	IEnumerator tutorialDano() {
		//animação inimigo tomando dano
		Animator NPCAnim = GameObject.FindGameObjectWithTag ("battleCherobin").GetComponent<Animator> ();
		NPCAnim.SetBool ("tomarDano", true);
		yield return new WaitForSeconds (0.5f);
		NPCAnim.SetBool ("tomarDano", false);
		//fim da animação
	}

	void Player1Fight()
	{
		Animator playerAnim = GameObject.FindGameObjectWithTag ("battlePlayer").GetComponent<Animator>();

		playerAnim.SetBool ("atacar", true);
		atacar = true;
	}

	void Player1FightCritico()
	{
		Animator playerAnim = GameObject.FindGameObjectWithTag ("battlePlayer").GetComponent<Animator>();

		playerAnim.SetBool ("hello", true);
		helloworld = true;
	}

	public void PassarTurno()
	{
		desabilitarBotoes ();
		StartCoroutine (passarTime ());
		SwitchPlayers();
		//Application.LoadLevel("gameover");

	}

	IEnumerator passarTime(){
		Animator playerAnim = GameObject.FindGameObjectWithTag ("battlePlayer").GetComponent<Animator>();
		playerAnim.SetBool ("passar", true);
		passar = true;
		yield return new WaitForSeconds (2f);
		playerAnim.SetBool ("passar", false);
		passar = false;
		yield return new WaitForSeconds(2.9f);	
		habilitarBotoes ();
	}

	void Player1cura()
	{
		Animator playerAnim = GameObject.FindGameObjectWithTag ("battlePlayer").GetComponent<Animator>();
		playerAnim.SetBool ("hamburgao", true);
		curar = true;
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
        else if (player1Turn)
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
        else if (player1Turn)
        {
            statusText.text = "Você NÃO tem mana suficiente";
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

	void desabilitarSkills(){
		curar = false;
		helloworld = false;
		passar = false;
		atacar = false;
	}

	void desabilitarNPCs (){
		TriggerAluno2f.aluno2f = false;
		TriggerNapoleao.napoleao = false;
		TriggerClaytinho.claytinho = false;
		TriggerTutorial.tutorial = false;
	}

	private void OnEnable()
	{
		Sair.interactable = false;
		desabilitarSkills ();
		habilitarBotoes ();
		Time.timeScale = 1;
		player1Turn = true;
		StartPlayer1Turn();
	}
		
	private void OnDisable()
	{
		Sair.interactable = false;

		player1Turn = true;
		player1Health = 100;
		player2Health = 100;
		mana = 100;
		player1Text.text = "Vida: " + player1Health + " Mana: " + mana;
		player2Text.text = "Vida: " + player2Health;
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




