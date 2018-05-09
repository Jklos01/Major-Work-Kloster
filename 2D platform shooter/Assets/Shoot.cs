using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	public float firerate = 0;
	public float damage = 10;
	public LayerMask notToHit;

	float timeToFire = 0;
	Transform firePoint;

	// Use this for initialization
	void Awake () {
		firePoint = transform.Find ("FirePoint");
		if (firePoint == null) {
			Debug.LogError ("No firepoint? WHAT!");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (firerate == 0) {
			if (Input.GetButtonDown ("Fire1")) {
				Shot ();
			}
		} else {
			if (Input.GetButton ("Fire1") && Time.time > timeToFire) {
				timeToFire = Time.time + 1 / firerate;
				Shot ();
			}
		}
	}

	void Shot (){
		
	}
}
