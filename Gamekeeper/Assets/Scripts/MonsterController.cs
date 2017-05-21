using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour {

	public Rigidbody rb;
	public float max;
	public float min;
	public float speed;
	public float range;


	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.AddForce (rb.transform.right * speed);
		/*
		rb.position = new Vector3 (rb.position.x , Mathf.SmoothStep(min, max, t), rb.position.z);

		// .. and increate the t interpolater
		t += range ;

		// now check if the interpolator has reached 1.0
		// and swap maximum and minimum so game object moves
		// in the opposite direction.

		if (t > max)
		{
			float temp = max;
			max = min;
			min = temp;
			t = 0.0f;
		}*/
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Boundary")
			Destroy (this.gameObject);
	}
}
