using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPcontroller : MonoBehaviour {

	public static int xp = 0;
	public Text testeXP;


	// Update is called once per frame
	void Update () {
		testeXP.text = "XP: " + xp;
	}
}
