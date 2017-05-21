using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBlock : MonoBehaviour {

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Bullet") {
			Debug.Log ("Block");
			Destroy (other.gameObject);
		}
	}
}
