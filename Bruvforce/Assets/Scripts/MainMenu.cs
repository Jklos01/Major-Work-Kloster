using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
//load the game scene
	public void Playgame (){
		SceneManager.LoadScene(1);
	}
//quit the game
	public void QuitGame (){
		Debug.Log("Quit");
		Application.Quit();
	}
}
