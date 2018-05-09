using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed = 5.0f;
	public float jumpheight;
	public bool canjump = true;

	private Rigidbody2D rigid;
	private Animator animator; 

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();
		rigid = this.GetComponent<Rigidbody2D> ();
		canjump = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey (KeyCode.D)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
			animator.SetInteger ("MoveState", 1);
        } else if (Input.GetKey (KeyCode.A)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
			animator.SetInteger ("MoveState", 1);
		} else {
			animator.SetInteger ("MoveState", 0);
		}


		if (Input.GetKey (KeyCode.Space) && canjump == true) {
			rigid.velocity = new Vector2 (0, jumpheight);
			canjump = false;
		}
	}
		
	void OnCollisionStay2D(Collision2D collider){
		CheckIfGrounded ();
	}

	private void CheckIfGrounded (){
		RaycastHit2D[] hits;

		Vector2 positionToCheck = transform.position;
		hits = Physics2D.RaycastAll (positionToCheck, new Vector2 (0, -1), 0.01f);

		if (hits.Length > 0) {
			canjump = true;
		}
	}
}
