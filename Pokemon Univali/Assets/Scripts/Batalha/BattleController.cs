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

	//poderes
	public Button poder1;
	public Button poder2;
	public Button poder3;
	public Button poder4;
	public Button poder5;

	public GameObject poderNapo;
	public GameObject itemNapo;

	public GameObject napoleao;
	//fim dos poderes

	public GameObject Sair;
    public GameObject battle;
	public GameObject gatilhoParaBatalha;

	public GameObject blockNapoleao;

    int player1Health = 100;
    int player2Health = 100;
    int mana = 100;



	private bool curar = false;
	private bool napo = false;
	private bool helloworld = false;
	private bool passar = false;
	private bool atacar = false;

    bool player1Turn = true;

    // Use this for initialization
    void Start()
	{
		//Time.timeScale = 1;
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

//		if (napoItem.coletouNapo == true) {
//			itemNapo.SetActive (false);
//			poderNapo.SetActive (true);
//		}

		if (player2Health <= 0){

			if (TriggerAluno2f.aluno2f == true) {
				XPcontroller.xp += 10;
			}

			if (TriggerTutorial.tutorial == true) {
				XPcontroller.xp += 20;
				TriggerTutorial.tutorial = false;
			}

			if (TriggerClaytinho.claytinho == true) {
				XPcontroller.xp += 16;
			}

			if (TriggerNapoleao.napoleao == true) {
				XPcontroller.xp += 54;
				blockNapoleao.SetActive (false);
				Destroy(napoleao, 0F);
				itemNapo.SetActive (true);
				//poderNapo.SetActive (true);
			}

			if (TriggerAdorno.adorno == true) {
				XPcontroller.xp += 76;
//				blockNapoleao.SetActive (false);
//				poderNapo.SetActive (true);
			}

			statusText.text = " Você VENCEU!";
			//StartCoroutine(win());

			desabilitarBotoes ();
			player2Health = 0;

			Sair.SetActive (true);
			Time.timeScale = 0;
		}

		if (player1Health < 1){
			StopCoroutine (Player2Turn());

			desabilitarBotoes ();
            player1Health = 0;
			StartCoroutine(gameover());			
		}
    }

	IEnumerator win(){
		yield return new WaitForSeconds (4f);
		gatilhoParaBatalha.GetComponent<GatilhoCompartilhado> ().falaTrigger = false;
		gatilhoParaBatalha.GetComponent<GatilhoCompartilhado> ().battleTrigger = false;
		gatilhoParaBatalha.GetComponent<GatilhoCompartilhado> ().fechou = false;
		desabilitarNPCs ();
		battle.SetActive (false);
	}

	IEnumerator gameover(){
		statusText.text = " Você PERDEU!";

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
        //Time.timeScale = 1;
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

			int cura = Random.Range(25*XPcontroller.bonus, 50*XPcontroller.bonus);
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

			int damage = Random.Range(100*XPcontroller.bonus, 200*XPcontroller.bonus);

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
			if (TriggerAdorno.adorno == true){
				Animator NPCAnim = GameObject.FindGameObjectWithTag ("battleAdorno").GetComponent<Animator> ();
				NPCAnim.SetBool ("tomarDano", true);
				yield return new WaitForSeconds (0.5f);
				NPCAnim.SetBool ("tomarDano", false);
			}
			//fim da gambiarra

			player2Health -= damage;
			yield return new WaitForSeconds (0.4f);
			helloworld = false;

		}

		if (napo == true) {
			Animator playerAnim = GameObject.FindGameObjectWithTag ("battlePlayer").GetComponent<Animator> ();
			statusText.text = " Você Crackeou o Photoshop!!";
			yield return new WaitForSeconds (1.40f);
			playerAnim.SetBool ("atacar", false);

			int damage = Random.Range(1*XPcontroller.bonus, 112*XPcontroller.bonus);

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
			if (TriggerAdorno.adorno == true){
				Animator NPCAnim = GameObject.FindGameObjectWithTag ("battleAdorno").GetComponent<Animator> ();
				NPCAnim.SetBool ("tomarDano", true);
				yield return new WaitForSeconds (0.5f);
				NPCAnim.SetBool ("tomarDano", false);
			}
			//fim da gambiarra

			player2Health -= damage;
			yield return new WaitForSeconds (1f);
			napo = false;
		}

		if (atacar == true) {
			Animator playerAnim = GameObject.FindGameObjectWithTag ("battlePlayer").GetComponent<Animator> ();
			statusText.text = " Você atacou!";
			yield return new WaitForSeconds (1.40f);
			playerAnim.SetBool ("atacar", false);

			int damage = Random.Range(25*XPcontroller.bonus, 30*XPcontroller.bonus);

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
			if (TriggerAdorno.adorno == true){
				Animator NPCAnim = GameObject.FindGameObjectWithTag ("battleAdorno").GetComponent<Animator> ();
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

		if (TriggerTutorial.tutorial == true) {
			if (player2Health >= 20) {
				statusText.text = " Cherobin atacou normalmente!";
				yield return new WaitForSeconds (2.5f);

				int damage = Random.Range (15, 25);
				player1Health -= damage;

				// animação do player tomando dano
				Animator playerAnim = GameObject.FindGameObjectWithTag ("battlePlayer").GetComponent<Animator> ();
				playerAnim.SetBool ("tomarDano", true);
				yield return new WaitForSeconds (0.5f);
				playerAnim.SetBool ("tomarDano", false);
			}

			if (player2Health < 20) {
				statusText.text = " Cherobin deu um super ataque";
				yield return new WaitForSeconds (2.5f);

				int damage = Random.Range (35, 45);
				player1Health -= damage;

				// animação do player tomando dano
				Animator playerAnim = GameObject.FindGameObjectWithTag ("battlePlayer").GetComponent<Animator> ();
				playerAnim.SetBool ("tomarDano", true);
				yield return new WaitForSeconds (0.5f);
				playerAnim.SetBool ("tomarDano", false);

			}

//			if (player2Health <= 30) {
//				statusText.text = " Cherobin se curou!";
//				yield return new WaitForSeconds (2.5f);	
//				int cura = Random.Range (35, 50);
//				player2Health += cura;  
//			}
		}

		if (TriggerClaytinho.claytinho == true) {
			if (player2Health >= 65) {
				statusText.text = " Claytinho atacou normalmente!";
				yield return new WaitForSeconds (2.5f);

				int damage = Random.Range (25, 30);
				player1Health -= damage;

				// animação do player tomando dano
				Animator playerAnim = GameObject.FindGameObjectWithTag ("battlePlayer").GetComponent<Animator> ();
				playerAnim.SetBool ("tomarDano", true);
				yield return new WaitForSeconds (0.5f);
				playerAnim.SetBool ("tomarDano", false);
			}

			if (player2Health < 65 && player2Health > 30) {
				statusText.text = " Claytinho deu um super ataque";
				yield return new WaitForSeconds (2.5f);

				int damage = Random.Range (35, 50);
				player1Health -= damage;

				// animação do player tomando dano
				Animator playerAnim = GameObject.FindGameObjectWithTag ("battlePlayer").GetComponent<Animator> ();
				playerAnim.SetBool ("tomarDano", true);
				yield return new WaitForSeconds (0.5f);
				playerAnim.SetBool ("tomarDano", false);

			}

			if (player2Health <= 30) {
				statusText.text = " Claytinho se curou!";
				yield return new WaitForSeconds (2.5f);	
				int cura = Random.Range (10, 50);
				player2Health += cura;  
			}
		}

		if (TriggerAluno2f.aluno2f == true) {
			if (player2Health >= 65) {
				statusText.text = " Aluno da 2ª fase atacou normalmente!";
				yield return new WaitForSeconds (2.5f);

				int damage = Random.Range (20, 25);
				player1Health -= damage;

				// animação do player tomando dano
				Animator playerAnim = GameObject.FindGameObjectWithTag ("battlePlayer").GetComponent<Animator> ();
				playerAnim.SetBool ("tomarDano", true);
				yield return new WaitForSeconds (0.5f);
				playerAnim.SetBool ("tomarDano", false);
			}

			if (player2Health < 65 && player2Health > 30) {
				statusText.text = " Aluno da 2ª fase deu um super ataque";
				yield return new WaitForSeconds (2.5f);

				int damage = Random.Range (25, 50);
				player1Health -= damage;

				// animação do player tomando dano
				Animator playerAnim = GameObject.FindGameObjectWithTag ("battlePlayer").GetComponent<Animator> ();
				playerAnim.SetBool ("tomarDano", true);
				yield return new WaitForSeconds (0.5f);
				playerAnim.SetBool ("tomarDano", false);

			}

			if (player2Health <= 30) {
				statusText.text = " Aluno da 2ª fase se curou!";
				yield return new WaitForSeconds (2.5f);	
				int cura = Random.Range (10, 50);
				player2Health += cura;  
			}
		}

		if (TriggerNapoleao.napoleao == true) {
			if (player2Health >= 65) {
				statusText.text = " Napoleão atacou normalmente!";
				yield return new WaitForSeconds (2.5f);

				int damage = Random.Range (30, 36);
				player1Health -= damage;

				// animação do player tomando dano
				Animator playerAnim = GameObject.FindGameObjectWithTag ("battlePlayer").GetComponent<Animator> ();
				playerAnim.SetBool ("tomarDano", true);
				yield return new WaitForSeconds (0.5f);
				playerAnim.SetBool ("tomarDano", false);
			}

			if (player2Health < 65 && player2Health > 30) {
				statusText.text = " Napoleão usou o Raio Boardgamezador";
				yield return new WaitForSeconds (2.5f);

				int damage = Random.Range (50,60);
				player1Health -= damage;

				// animação do player tomando dano
				Animator playerAnim = GameObject.FindGameObjectWithTag ("battlePlayer").GetComponent<Animator> ();
				playerAnim.SetBool ("tomarDano", true);
				yield return new WaitForSeconds (0.5f);
				playerAnim.SetBool ("tomarDano", false);

			}

			if (player2Health <= 30) {
				statusText.text = " Napoleão se curou!";
				yield return new WaitForSeconds (2.5f);	
				int cura = Random.Range (35, 50);
				player2Health += cura;  
			}
		}

		if (TriggerAdorno.adorno == true) {
			if (player2Health >= 65) {
				statusText.text = " Adorno usou cobrar pasta A4";
				yield return new WaitForSeconds (2.5f);

				int damage = Random.Range (30, 36);
				player1Health -= damage;

				// animação do player tomando dano
				Animator playerAnim = GameObject.FindGameObjectWithTag ("battlePlayer").GetComponent<Animator> ();
				playerAnim.SetBool ("tomarDano", true);
				yield return new WaitForSeconds (0.5f);
				playerAnim.SetBool ("tomarDano", false);
			}

			if (player2Health < 65 && player2Health > 30) {
				statusText.text = " Adorno usou cobrar pasta A3";
				yield return new WaitForSeconds (2.5f);

				int damage = Random.Range (50,60);
				player1Health -= damage;

				// animação do player tomando dano
				Animator playerAnim = GameObject.FindGameObjectWithTag ("battlePlayer").GetComponent<Animator> ();
				playerAnim.SetBool ("tomarDano", true);
				yield return new WaitForSeconds (0.5f);
				playerAnim.SetBool ("tomarDano", false);

			}

			if (player2Health <= 30) {
				statusText.text = " Adorno se curou!";
				yield return new WaitForSeconds (2.5f);	
				int cura = Random.Range (35, 50);
				player2Health += cura;  
			}
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

	void Player1napo()
	{
		Animator playerAnim = GameObject.FindGameObjectWithTag ("battlePlayer").GetComponent<Animator>();

		playerAnim.SetBool ("atacar", true);
		napo = true;
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
            //mana -= 25;
            Player1cura();
            SwitchPlayers();
        }
        else if (player1Turn)
        {
            statusText.text = "Você NÃO tem mana suficiente";
        }
    }

	public void napoSkill()
	{
		if (player1Health > 0 && player1Turn && mana >= 25)
		{
			mana -= 25;
			Player1napo();
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
		poder5.interactable = true;	
	}

	void desabilitarBotoes(){
		poder1.interactable = false;
		//poder2.interactable = false;
		poder3.interactable = false;
		poder4.interactable = false;
		poder5.interactable = false;	
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
		TriggerAdorno.adorno = false;
	}

	private void OnEnable()
	{
		Sair.SetActive(false);
		desabilitarSkills ();
		habilitarBotoes ();
		Time.timeScale = 1;
		if (TriggerAluno2f.aluno2f == true){
			player2Health = 50;
		}
		player1Turn = true;
		StartPlayer1Turn();
	}
		
	private void OnDisable()
	{
		Sair.SetActive(false);

		player1Turn = true;
		//player1Health = 100;
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




