using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour {

	public float speed;

	private Transform player;
	private Vector2 target;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
//target is the position of the player
		target = new Vector2(player.position.x, player.position.y);
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
		if(other.CompareTag("Player")){
			Destroy(this.gameObject);
		}
	}


}
