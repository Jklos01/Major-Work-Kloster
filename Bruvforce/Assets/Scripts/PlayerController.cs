using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {
	public float speed = 5.0f;
	public float jumpheight;
	public bool canjump = true;
	public float ammo = 20f;


	public Text ammoText;

	public Transform bulletspawn;
	public GameObject bullet;
	GameObject tempbullet;


	Rigidbody2D rigid;
	Animator animator;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();
		rigid = this.GetComponent<Rigidbody2D> ();
		canjump = true;

		setAmmoText();

		bulletspawn = this.gameObject.transform.GetChild(1);
        
	}

	void FixedUpdate () {
		if (Input.GetKey (KeyCode.D)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
        } else if (Input.GetKey (KeyCode.A)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.Space) && canjump == true) {
			rigid.velocity = new Vector2 (0, jumpheight);
			canjump = false;
		}
        
		if (Input.GetMouseButtonDown(0) && ammo >= 1){
			if ( ! EventSystem.current.IsPointerOverGameObject())
			{
				tempbullet = Instantiate(bullet, bulletspawn.position, Quaternion.identity);
				ammo--;
				setAmmoText();
				Destroy(tempbullet, 10f);
			}
		}
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Ground"){
			canjump = true;
		}

		if(collision.tag == "Ammo"){
			ammo += 20;
			setAmmoText();
			Destroy(collision.gameObject);
		}
	}

	void setAmmoText(){
		ammoText.text = "Ammo: " + ammo.ToString();
	}
}
