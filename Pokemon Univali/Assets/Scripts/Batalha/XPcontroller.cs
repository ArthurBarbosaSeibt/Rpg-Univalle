using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPcontroller : MonoBehaviour {

	public static int xp = 0;
	public static int oldxp = 0;
	public Text testeXP;
	public Image barraXP;
	public Image level;

	public Sprite lvl2;
	public Sprite lvl3;
	public Sprite lvl4;
	public Sprite lvl5;

	public Sprite zero;
	public Sprite um;
	public Sprite dois;
	public Sprite tres;
	public Sprite quatro;
	public Sprite cinco;
	public Sprite seis;
	public Sprite sete;
	public Sprite oito;
	public Sprite nove;
	public Sprite dez;
	public Sprite dez1;
	public Sprite dez2;
	public Sprite dez3;
	public Sprite dez4;
	public Sprite dez5;
	public Sprite dez6;
	public Sprite dez7;
	public Sprite dez8;
	public Sprite dez9;
	public Sprite vinte;
	public Sprite vinte1;
	public Sprite vinte2;
	public Sprite vinte3;
	public Sprite vinte4;
	public Sprite vinte5;

	bool lvlup = false;
	int i = 0;

	// Update is called once per frame
	void Update () {
		testeXP.text = "XP: " + xp;
		//while (i >= 4) {
			if (xp >= 0 && xp <= 4)
				barraXP.sprite = zero;

			if (xp >= 4 && xp <= 8)
				barraXP.sprite = um;

			if (xp >= 8 && xp <= 12)
				barraXP.sprite = dois;

			if (xp >= 12 && xp <= 16)
				barraXP.sprite = tres;

			if (xp >= 16 && xp <= 20)
				barraXP.sprite = quatro;

			if (xp >= 20 && xp <= 24)
				barraXP.sprite = cinco;

			if (xp >= 24 && xp <= 28)
				barraXP.sprite = seis;

			if (xp >= 28 && xp <= 32)
				barraXP.sprite = sete;

			if (xp >= 32 && xp <= 36)
				barraXP.sprite = oito;

			if (xp >= 36 && xp <= 40)
				barraXP.sprite = nove;

			if (xp >= 40 && xp <= 44)
				barraXP.sprite = dez;

			if (xp >= 44 && xp <= 48)
				barraXP.sprite = dez1;
	
			if (xp >= 48 && xp <= 52)
				barraXP.sprite = dez2;

			if (xp >= 52 && xp <= 56)
				barraXP.sprite = dez3;

			if (xp >= 60 && xp <= 64)
				barraXP.sprite = dez4;
	
			if (xp >= 64 && xp <= 68)
				barraXP.sprite = dez5;

			if (xp >= 68 && xp <= 72)
				barraXP.sprite = dez6;

			if (xp >= 72 && xp <= 76)
				barraXP.sprite = dez7;

			if (xp >= 76 && xp <= 80)
				barraXP.sprite = dez8;

			if (xp >= 80 && xp <= 84)
				barraXP.sprite = dez9;
		
			if (xp >= 84 && xp <= 88)
				barraXP.sprite = vinte;
	
			if (xp >= 88 && xp <= 92)
				barraXP.sprite = vinte2;

			if (xp >= 92 && xp <= 96)
				barraXP.sprite = vinte4;

			if (xp >= 96 && xp <= 100) {
				barraXP.sprite = vinte5;
				lvlup = true;
			}

			if (lvlup == true) {
				level.sprite = lvl2;
				oldxp = xp;
				xp = 0;
				lvlup = false;
			}

			if (i == 2) {
				level.sprite = lvl3;
				xp = 0;
			}

			if (i == 3) {
				level.sprite = lvl4;
				xp = 0;
			}

			if (i == 4) {
				level.sprite = lvl5;
				xp = 0;
			}
		}
	//}
}
