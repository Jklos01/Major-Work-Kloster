using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	public int enemyHealth = 10;
	public float speed;

	private bool movingRight = true;

	public Transform groundDetection;

	private float shootDelay;
	public float startDelay;

	public GameObject Bullet;


	public GameObject Player;

	void Start () {
		shootDelay = startDelay;
	}

	// Update is called once per frame
	void Update () {
		if(enemyHealth <= 0){
			Destroy(this.gameObject);
		}
		// makes the enemy continually move to the right
		transform.Translate(Vector2.right * speed * Time.deltaTime);

		//detects infront of the enenmy for a ground, if no ground is found the enemy turns around.
		RaycastHit2D groundinfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
		if(groundinfo.collider == false){
			if(movingRight == true){
					transform.eulerAngles = new Vector3(0, -180, 0);
					movingRight = false;
			} else {
					transform.eulerAngles = new Vector3(0 , 0, 0);
					movingRight = true;
			}
		}
		//must be within 20 'x' units to start shooting at player
		if (this.transform.position.x - Player.transform.position.x < 20){
				if(shootDelay <= 0){
				Instantiate(Bullet, transform.position, Quaternion.identity);
				shootDelay = startDelay;
			} else{
				shootDelay -= Time.deltaTime;
			}
		}
	}
// if an enemy collides with another enemy, turn around
	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "Enemy")
	       {
					 if(movingRight == true){
							transform.eulerAngles = new Vector3(0, -180, 0);
							movingRight = false;
					} else {
							transform.eulerAngles = new Vector3(0 , 0, 0);
							movingRight = true;
					}
	       }
	}

	//if a bullet hits the enemy they  lose health
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "bullet"){
			enemyHealth -= 5;
		}
	}
}
