using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	public GameObject bullet;
	public Transform spawner;

	Vector3 shootdirection;

	private void Start()
	{
		shootdirection = Input.mousePosition;
		shootdirection = Camera.main.ScreenToWorldPoint(shootdirection);
        shootdirection.z = 0.0f;
        shootdirection = shootdirection - spawner.position;
	}

	private void Update()
	{
		if (Input.GetMouseButton(0)){
			Debug.Log("Pressed Fire");
			GameObject shot = Instantiate(bullet, spawner.position, Quaternion.Euler(new Vector3(0,0,0))) as GameObject;
			shot.GetComponent<Rigidbody2D>().AddForce(shootdirection);
		}
	}

}
