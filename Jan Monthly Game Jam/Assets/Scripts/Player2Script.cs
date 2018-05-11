using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Script : MonoBehaviour {

	public GameObject[] options; 
	public GameObject gameManager;
	public Transform spawnPoint;
	public bool covSelectDone = false;
	public float smothing = 1f;
	public string finalPlay;
	public string firstPlay;
	public KeyCode rock;
	public KeyCode paper;
	public KeyCode scissor;

	GameManagerScript gameManagerInfo;

	public GameObject choice;
	public GameObject finalChoice;


	private void Start () {
		gameManagerInfo = gameManager.GetComponent <GameManagerScript> ();
		//Reset ();
	}

	private void Update () {
		// if at the first stage
		if (covSelectDone == false && gameManagerInfo.gameStart == true) {
			// select and wait
			Select ();
	
			// play some animations to move the first choice

		}

		// rotate the first played card
		if (gameManagerInfo.GetAllDone() == true) {			
			//rotate the choice
			StartCoroutine (WaitAndRotate ());
			StopCoroutine (WaitAndRotate ());
		}

		// final stage, the second choose
		if (gameManagerInfo.GetFinalStage () == true) {
			// select
			Debug.Log ("select start");
			finalPlay = finalChoice.tag;
			SelectFinal ();

			//play some animation to reveal the final choice

		}
	}

	// rotate the choice
	IEnumerator WaitAndRotate () {
		Debug.Log ("wait and rotate");
		yield return new WaitForSeconds (gameManagerInfo.waitBeforeRot);
		if (choice != null) {
			Quaternion currentRotation = choice.transform.rotation;
			Quaternion endRotation = Quaternion.Euler (0, 180, 0);
			choice.transform.rotation = Quaternion.Lerp (currentRotation, endRotation, Time.deltaTime * smothing);
		}
		yield return new WaitForSeconds (gameManagerInfo.readAfterRot);
		// set the stage
		gameManagerInfo.OpenSecondStage ();
		gameManagerInfo.CloseFirstStage ();

	}

	// Select the cover
	// since no need to compare but to show to the player but should still record the info into some vairable
	private void Select () {

		// Rock
		if (Input.GetKeyDown (rock)) {
			Debug.Log ("call select");
			choice = Instantiate (options[0], spawnPoint);
			covSelectDone = true;
			firstPlay = choice.tag;
			finalChoice = choice;
		}
		// Paper
		if (Input.GetKeyDown (paper)) {
			Debug.Log ("call select");
			choice = Instantiate (options[1], spawnPoint);
			covSelectDone = true;
			firstPlay = choice.tag;
			finalChoice = choice;
		}
		// Scissor
		if (Input.GetKeyDown (scissor)) {
			Debug.Log ("call select");
			choice = Instantiate (options[2], spawnPoint);
			covSelectDone = true;
			firstPlay = choice.tag;
			finalChoice = choice;
		}
	}

	private void SelectFinal () {

		// Rock
		if (Input.GetKeyDown (rock)) {
			//Debug.Log ("call final select");
			finalChoice = Instantiate (options[0], spawnPoint);
		}
		// Paper
		if (Input.GetKeyDown (paper)) {
			//Debug.Log ("call final select");
			finalChoice = Instantiate (options[0], spawnPoint);
		}
		// Scissor
		if (Input.GetKeyDown (scissor)) {
			//Debug.Log ("call final select");
			finalChoice = Instantiate (options[0], spawnPoint);
		}
	}

	public void Reset () {
		covSelectDone = false;
		firstPlay = "";
		finalPlay = "";
		if (choice != null) {
			GameObject temp = choice;
			Destroy (temp);
		}
		choice = null;
		finalChoice = null;
	}
}
