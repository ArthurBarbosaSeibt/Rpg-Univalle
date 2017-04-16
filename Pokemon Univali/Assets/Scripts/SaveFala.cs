using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveFala : MonoBehaviour {

	public static string texto;
	void Start () {
		texto = GetComponent<Text>().text;
	}

}
