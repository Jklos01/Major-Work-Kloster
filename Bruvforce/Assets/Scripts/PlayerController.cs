﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    // Outline all the variables
	public float speed = 5.0f;
	public float jumpheight;
	public bool canjump = true;
	public bool canmove = true;

	public int ammo = 20;
	public int health = 3;


	public GameObject life1;
	public GameObject life2;
	public GameObject life3;
	public GameObject DeathUI;

	public Text ammoText;

	public Transform bulletspawn;
	public GameObject bullet;
	GameObject tempbullet;


	Rigidbody2D rigid;
	CapsuleCollider2D capsuleCollider2D;
	CircleCollider2D circleCollider2D;


	public GameObject FinishScreen;

	// Use this for initialization
	void Start () {
		// As the program starts, get a reference of each of the outlined variables that aren't
		// being referenced publically in the editor.
		rigid = this.GetComponent<Rigidbody2D> ();
		capsuleCollider2D = this.GetComponent<CapsuleCollider2D>();
		circleCollider2D = this.GetComponent<CircleCollider2D>();
		canjump = true;

		setAmmoText();

		bulletspawn = this.gameObject.transform.GetChild(1);

	}

	void FixedUpdate () {
		// Basic movement using the A and D keys to go left and right
		if (Input.GetKey (KeyCode.D) && canmove == true) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		} else if (Input.GetKey (KeyCode.A) && canmove == true) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		// Basic jump function using the space bar
		if (Input.GetKey (KeyCode.Space) && canjump == true && canmove == true) {
			rigid.velocity = new Vector2 (0, jumpheight);
			canjump = false;
		}
		// Shoot a bullet on click
		if (Input.GetMouseButtonDown(0) && ammo >= 1 && canmove == true){
			if ( ! EventSystem.current.IsPointerOverGameObject())
			{
				tempbullet = Instantiate(bullet, bulletspawn.position, Quaternion.identity);
				ammo--;
				setAmmoText();
				Destroy(tempbullet, 10f);
			}
		}
	}

//Makes the health sprites inactive
	void checkHealth(){
		if (health == 2){
			life3.SetActive(false);
		}
		if (health == 1)
        {
			life3.SetActive(false);
			life2.SetActive(false);
        }
		if (health == 0)
        {
			life3.SetActive(false);
            life2.SetActive(false);
            life1.SetActive(false);
			canmove = false;
			StartCoroutine(death());
        }
	}

    // Death Function that runs when health reaches 0.

	IEnumerator death(){
		// Adds a small force to the character to make him jump similar to how Mario dies in Mario games and removes all collisions
        // so that the character falls through the floor, again like Mario.
		rigid.velocity = new Vector2(0, jumpheight);
		circleCollider2D.enabled = false;
        capsuleCollider2D.enabled = false;

        // Waits a second before pausing the game so that the character begins to fall through the floor in a Mario style death
		yield return new WaitForSeconds(1);
		Time.timeScale = 0;
        // Activates the Death Menu that allows the player to retry or go to menu.
		DeathUI.SetActive(true);
	}
// remove health when colliding with enemy
	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "Enemy")
	       {
	           health -= 1;
	           Debug.Log("Lost some health");
	           checkHealth();
	       }
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		// reset the jump bool when colliding wiht the ground
		if(collision.tag == "Ground"){
			canjump = true;
		}
		// remove health when colliding with a bullet
		if (collision.gameObject.tag == "enemybullet")
	       {
	           health -= 1;
	           Debug.Log("Lost some health");
	           checkHealth();
	       }
	 // increase ammo count if colliding wiht ammo box
		if(collision.tag == "Ammo"){
			ammo += 20;
			setAmmoText();
			Destroy(collision.gameObject);
		}
		// die if you fall off the map
		if (collision.tag == "deathbox"){
			health = 0;
			checkHealth();
			StartCoroutine(death());
		}
		// end the game if you beat the level
		if (collision.tag == "flag"){
				Time.timeScale = 0f;
				FinishScreen.SetActive(true);
		}
	}
// sets the ammo text to whatever ammo count is.
	void setAmmoText(){
		ammoText.text = "Ammo: " + ammo.ToString();
	}
}
