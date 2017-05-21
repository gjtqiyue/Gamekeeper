using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunController : MonoBehaviour {
	
	public float sensitivity;
	public float fireRate;

	public GameObject bullet;
	public Transform shotSpawn;

	private float nextFire;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float rotX = Input.GetAxis ("Mouse X") * sensitivity * Time.deltaTime;
		float rotY = Input.GetAxis ("Mouse Y") * sensitivity * Time.deltaTime;

		transform.Rotate (rotY, rotX, 0);

		Fire ();
	}

	public void Fire ()
	{
		if (Input.GetKey (KeyCode.F) && Time.time > nextFire && GameController.Instance.canFire) {
			nextFire = Time.time + fireRate;
			GameObject bulletTemp = Instantiate (bullet, shotSpawn.position, shotSpawn.rotation); //as GameObject;

			Destroy (bulletTemp, 10.0f);

		}
	}
		
}
