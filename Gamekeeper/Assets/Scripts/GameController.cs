using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoSingleton<GameController> {

	public GameObject[] monsters;
	public Vector3 spawnValues;
	public float startWait;
	public float spawnWait;
	public float waveWait;
	public int monsterCount;
	public float timeLeft;
	public int numOfCollect;

	public Text timer;
	public Text goalText;
	public Image warningImage;
	public Image restartImage;
	public Image nextLevelImage;

	public bool imageIsOn = false;
	public bool canFire = false;

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnMonsters ());
		goalText.text = "Target Left: " + numOfCollect ;
		timer.text = string.Format("{0:00.00}", "0");
		warningImage.GetComponent <Image> ();
		restartImage.GetComponent <Image> ();
		nextLevelImage.GetComponent <Image> ();
		warningImage.enabled = false;
		restartImage.enabled = false;
		nextLevelImage.enabled = false;
		canFire = true;
	}
	
	// Update is called once per frame
	void Update () {
		timer.text = string.Format("{0:00.00}", timeLeft);
		timeLeft -= Time.deltaTime;
		goalText.text = "Mutants Collected " + numOfCollect;
		
		// game over condition
		if (timeLeft <= 1) {
			timer.text = timer.text = string.Format("{0:00.00}", "0");
			Debug.Log ("Game Over");
			monsterCount = 0;
			canFire = false;
			restartImage.enabled = true;

			if (Input.GetKey (KeyCode.R)) {
				SceneManager.LoadScene ("MainScene");
			}
		}

		// level up condition
		if (numOfCollect == 10) {
			Debug.Log ("Next Level");
			monsterCount = 0;
			timer.text = "{0:00.00}";
			canFire = false;
			nextLevelImage.enabled = true;
		}
	
	}

	IEnumerator SpawnMonsters ()
	{
		//time break before the hazard
		yield return new WaitForSeconds (startWait);
		//create the wave so the game will continue
		while (true) {
			for (int i = 0; i < monsterCount; i++) { 
				GameObject monster = monsters [Random.Range (0, monsters.Length)];
				//set the range of the monster spwaner and randomly spawn
				Vector3 spawnPosition = new Vector3 (spawnValues.x, Random.Range (spawnValues.y - 5, spawnValues.y + 3.5f), Random.Range (-spawnValues.z, spawnValues.z));
				Quaternion spawnRotation = Quaternion.identity;
	            Instantiate (monster, spawnPosition, spawnRotation);
				//time break between every monster
				yield return new WaitForSeconds (spawnWait);
			}
			//time break after each wave
			yield return new WaitForSeconds (waveWait);

		}
	}
		
}
