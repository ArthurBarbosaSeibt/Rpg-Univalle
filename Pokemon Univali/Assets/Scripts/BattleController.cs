using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    public Text statusText;
    public Text player1Text;
    public Text player2Text;
    public GameObject battle;

    int player1Health = 100;
    int player2Health = 100;
    int mana = 100;

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
        if (player1Health < 1)
        {
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
        int damage = Random.Range(25, 35);
        player2Health -= damage;
        if (player2Health - damage == 0)
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

        int damage = Random.Range(50, 50);
        player2Health -= damage;
       
        if (player2Health <= 0)
        {
            player2Health = 0;
            statusText.text = " Você VENCEU!";
            Time.timeScale = 0;

        }

    }

    void Player1cura()
    {
		// variável para controlar a opacidade do player;
		Animator playerAnim = GameObject.FindGameObjectWithTag ("battlePlayer").GetComponent<Animator>();


		int cura = Random.Range(25, 50);
        player1Health += cura;
		playerAnim.SetBool ("hamburgao", true);

    }


    void SwitchPlayers()
    {
        player1Text.text = "Vida: " + player1Health + " Mana: " + mana ;
        player2Text.text = "Vida: " + player2Health;
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
        statusText.text = " Turno do oponente ...";
        StartCoroutine(Player2Turn());

    }

    IEnumerator Player2Turn()
    {
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
        if (player1Health - damage == 0)
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
        if (player1Health - damage == 0)
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

    public void PassarTurno()
    {
        if (player1Health > 0 && player1Turn)
        {
            
            SwitchPlayers();


        }
    }


}




