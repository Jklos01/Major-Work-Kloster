using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {
	public float speed = 5.0f;
	public float jumpheight;
	public bool canjump = true;


	public int ammo = 20;
	public int health = 3;


	public GameObject life1;
	public GameObject life2;
	public GameObject life3;

	public Text ammoText;

	public Transform bulletspawn;
	public GameObject bullet;
	GameObject tempbullet;


	Rigidbody2D rigid;

	// Use this for initialization
	void Start () {
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

	void checkHealth(){
		if (health == 2){
			life3.SetActive(false);
		}
		if (health == 1)
        {
			life2.SetActive(false);
        }
		if (health == 0)
        {
            life1.SetActive(false);
			dead();
        }
	}

	void dead(){
		
	}

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
