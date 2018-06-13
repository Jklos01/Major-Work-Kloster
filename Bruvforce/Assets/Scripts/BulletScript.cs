using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	public float velocityX = 100f;
	float velocityY = 0f;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector2(velocityX, velocityY);

	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag != "Player")
		{
			Destroy(this.gameObject);
		}

		if (collision.gameObject.tag == "Enemy"){
			
		}
	}
}
