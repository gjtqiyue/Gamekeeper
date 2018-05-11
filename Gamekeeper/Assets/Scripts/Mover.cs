using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
	public Rigidbody rb;
	public float speed;


	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.AddForce (transform.up * speed);



	}
		

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Monster") {
			GameControllerNextLevel.Instance.timeLeft -= 5;
			Debug.Log ("Enable");
			GameControllerNextLevel.Instance.warningImage.enabled = true;

			other.GetComponent <MeshRenderer> ().enabled = false;
			Destroy (other.gameObject);
			Destroy (this.gameObject);
			//Debug.Log ("Wrong one");

		}
		if (other.tag == "Boss") {
			Debug.Log ("That's the one");
			Destroy (other.gameObject);
			Destroy (this.gameObject);
			GameControllerNextLevel.Instance.numBossKilled +=1;
		}
		if (other.tag == "Collection") {
			GameControllerNextLevel.Instance.timeLeft = GameControllerNextLevel.Instance.allowedTime - 10;
			Destroy (other.gameObject);
			Destroy (this.gameObject);
			GameControllerNextLevel.Instance.numOfCollect += 1;
		}
	}
}
