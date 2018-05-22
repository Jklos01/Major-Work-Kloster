using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed = 5.0f;
	public float jumpheight;
	public bool canjump = true;


	public Transform bulletspawn;
	public GameObject bullet;
	GameObject tempbullet;

	public CircleCollider2D groundCheck;

	Rigidbody2D rigid;
	Animator animator;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();
		rigid = this.GetComponent<Rigidbody2D> ();
		canjump = true;

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
        
		if (Input.GetMouseButtonDown(0)){
			tempbullet = Instantiate(bullet, bulletspawn.position, Quaternion.identity);
			Destroy(tempbullet, 2f);
		}
	}


	void OnCollisionEnter2D(Collision2D collision)
	{
		
	    CheckIfGrounded ();
	}

	void CheckIfGrounded()
	{
		RaycastHit2D[] hits;

		Vector2 positionToCheck = transform.position;
		hits = Physics2D.RaycastAll(positionToCheck, new Vector2(0, -1), 0.01f);

		canjump |= hits.Length > 0;
	}
}
