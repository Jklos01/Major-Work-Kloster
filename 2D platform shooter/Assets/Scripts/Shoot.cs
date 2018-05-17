using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	public GameObject bullet;
	public Transform spawner;

	Vector3 shootdirection;

	private void Start()
	{
		shootdirection = Camera.main.ScreenToWorldPoint(shootdirection);
	}

	private void shoot(){

		shootdirection = Input.mousePosition;
        shootdirection.z = 0.0f;
        shootdirection = shootdirection - spawner.position;
	}

	private void Update()
	{
		shoot();

		if (Input.GetMouseButton(0)){
			Debug.Log(shootdirection);
			GameObject shot = Instantiate(bullet, spawner.position, Quaternion.Euler(new Vector3(0,0,0))) as GameObject;
			shot.GetComponent<Rigidbody2D>().AddForce(shootdirection);
			Destroy(shot, 3.0f);
		}
	}

}
