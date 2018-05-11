using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour {

	public Rigidbody rb;
	public float max;
	public float min;
	private float speed;
	public float maxS;
	public float minS;

	private float phase;


	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody> ();
		phase = Random.Range (min, max);
		speed = Random.Range (minS, maxS);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		transform.position = new Vector3 (transform.position.x + Time.deltaTime * speed, Mathf.Sin((Time.time + phase) * 3)  + 35, transform.position.z);

	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Boundary")
			Destroy (this.gameObject);
	}
}
