using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunController : MonoBehaviour {
	
	public float sensitivity;
	public float fireRate;
	public Rigidbody rb;

	public GameObject bullet;
	public Transform shotSpawn;
	public float min;
	public float max;

	private float nextFire;


	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		float rotX = Input.GetAxis ("Mouse X") * sensitivity * Time.deltaTime;
		float rotY = Input.GetAxis ("Mouse Y") * sensitivity * Time.deltaTime;

		rb.transform.Rotate (rotY, 0, 0);
		rb.transform.Rotate (0, rotX, 0, 0);

		Fire ();
	}

	public void Fire ()
	{
		if (Input.GetKey (KeyCode.Space) && Time.time > nextFire && GameControllerNextLevel.Instance.canFire) {
			nextFire = Time.time + fireRate;
			GameObject bulletTemp = Instantiate (bullet, shotSpawn.position, shotSpawn.rotation); //as GameObject;

			Destroy (bulletTemp, 10.0f);

		}
	}
		
}
