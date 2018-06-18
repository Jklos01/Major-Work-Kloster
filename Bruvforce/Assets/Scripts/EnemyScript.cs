using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	public int enemyHealth = 10;
	public float speed = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(enemyHealth <= 0){
			Destroy(this.gameObject);
		}
	}
  
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "bullet"){
			enemyHealth -= 5;
		}
	}
}
