using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Menu : MonoBehaviour {

    public void StartGame()
    {
        Time.timeScale = 1;
        Application.LoadLevel("unimon1");
        
    }
}
