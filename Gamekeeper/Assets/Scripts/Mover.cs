using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
	public Rigidbody rb;
	public float speed;
	public float delay;

	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

		rb.AddForce (transform.forward * speed);
	}

	IEnumerator timeCollapse () {
		GameController.Instance.timeLeft -= 5;
		Debug.Log ("Enable");
		GameController.Instance.warningImage.enabled = true;
		yield return new WaitForSeconds (delay);
		Debug.Log ("Disable");
		GameController.Instance.warningImage.enabled = false;
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Monster") {
			Destroy (other.gameObject);
			Destroy (this.gameObject);
			Debug.Log ("Wrong one");
			StartCoroutine (timeCollapse ());
		}
		if (other.tag == "Boss") {
			Debug.Log ("That's the one");
			Destroy (other.gameObject);
			Destroy (this.gameObject);
			GameController.Instance.numOfCollect += 1;
		}
	}
}
