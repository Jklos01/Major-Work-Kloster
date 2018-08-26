using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuScript : MonoBehaviour {

	public GameObject DeathUI;

	// Use this for initialization
	void Start () {
		DeathUI.SetActive(false);
	}

	public void retry(){
		DeathUI.SetActive(false);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		Time.timeScale = 1;
	}
}
