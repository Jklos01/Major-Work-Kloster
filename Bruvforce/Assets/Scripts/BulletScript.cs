using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	private Transform clickposition;
	private Vector2 target;
	public float speed = 20f;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		//target is the position of the mousclick
		target = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x,Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
	}


	void Update () {
		//make the bullet move towards the 'target' aka mouse click position at an angle
		transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
		//when the bullet reaches the position of the click, delete it
		if(transform.position.x == target.x && transform.position.y == target.y){
			Destroy(this.gameObject);
		}

	}
// delete itself when it collides
	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Enemy")){
			Destroy(this.gameObject);
		}
	}
}
