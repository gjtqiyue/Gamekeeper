using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerNextLevel : MonoSingleton<GameControllerNextLevel> {

	public GameObject[] monsters;
	public Vector3 spawnValues;
	public float startWait;
	public float spawnWait;
	public float waveWait;
	public int monsterCount;
	public float allowedTime;
	public int numOfCollect;
	public int numBossKilled;
	public int goalOfCollect = 10;
	public int randomTime;
	public int numOfBoss;
	public float delay;

	private bool gameStart = false;
	private bool gameOver = false;

	[HideInInspector]
	public float timeLeft;

	public Text timer;
	public Text goalText;
	public Image warningImage;
	public Image restartImage;
	public Image nextLevelImage;
	public Button nextLevel;
	public Button restart;

	public bool imageIsOn = false;
	public bool canFire = false;


	// Use this for initialization
	void Start () {
		startGame ();
		goalText.text = "Target Left: " + numOfCollect ;
		timer.text = string.Format("{0:00.00}", "0");
		warningImage.GetComponent <Image> ();
		restartImage.GetComponent <Image> ();
		nextLevelImage.GetComponent <Image> ();
		warningImage.enabled = false;
		restartImage.enabled = false;
		nextLevelImage.enabled = false;
		timeLeft = allowedTime;
	}
	
	// Update is called once per frame
	void Update () {
			
		
		timer.text = string.Format ("{0:00.00}", timeLeft);

		if (gameStart)
			timeLeft -= Time.deltaTime;

		goalText.text = "Collected " + numOfCollect;

		if (warningImage.enabled == true) {

			StartCoroutine (timeCollapse ());
		}

		// game over condition
		if (timeLeft <= 1) {
			timer.text = timer.text = string.Format ("{0:00.00}", "0");
			Debug.Log ("Game Over");
			monsterCount = 0;
			canFire = false;
			restartImage.enabled = true;
			gameOver = true;
			if (Input.GetKey (KeyCode.R))
				SceneManager.LoadScene ("Menu");
		}

		// level up condition
		if (numOfCollect >= goalOfCollect) {
			if (numOfBoss != 0) {
				if (numBossKilled >= numOfBoss) {
					timeLeft = allowedTime;
					Debug.Log ("Next Level");

					timer.text = string.Format ("{0:00.00}", timeLeft);
					canFire = false;
					gameStart = false;
					StartCoroutine (youWin ());
				}
			} else {
				if (gameOver == false) {
					timeLeft = allowedTime;
					Debug.Log ("Next Level");

					timer.text = string.Format ("{0:00.00}", timeLeft);
					canFire = false;
					gameStart = false;
					nextLevelImage.enabled = true;

					if (Input.GetKey (KeyCode.N)) {
						SceneManager.LoadScene ("NextLevel");
						gameOver = true;
					}
				}
			
			}
		}
	}
			

	IEnumerator youWin() {
		yield return new WaitForSeconds (3);
		SceneManager.LoadScene ("Menu");
	}
	
	

	IEnumerator SpawnMonsters(){
		Debug.Log ("start");
		yield return new WaitForSeconds (startWait);
		//create the wave so the game will continue
		while (true) {
			for (int i = 0; i < monsterCount; i++) {
				GameObject monster = monsters [Mathf.FloorToInt ( Random.Range (0, monsters.Length))];
				//set the range of the monster spwaner and randomly spawn
				Vector3 spawnPosition = new Vector3 (spawnValues.x, Random.Range (spawnValues.y - 5, spawnValues.y + 3.5f), Random.Range (-spawnValues.z, spawnValues.z));
				Quaternion spawnRotation = Quaternion.identity;
	            Instantiate (monster, spawnPosition, spawnRotation);
				//time break between every monster
				yield return new WaitForSeconds (spawnWait);
			}
			//time break after each wave
			yield return new WaitForSeconds (waveWait);
			if (gameObject.GetComponent <BossSpawner> () && numOfCollect >= goalOfCollect)
				gameObject.GetComponent <BossSpawner> ().Initialize ();
		}
	}


	public void restartButton () {
		SceneManager.LoadScene ("Menu");
	}

	public void nextLevelButton () {
		SceneManager.LoadScene ("NextLevel");
	}
		
	public void startGame () {
		StartCoroutine (SpawnMonsters ());
		canFire = true;
		gameStart = true;
	}

	IEnumerator timeCollapse () {
		yield return new WaitForSeconds (delay);
		Debug.Log ("Disable");
		warningImage.enabled = false;
		StopCoroutine (timeCollapse ());
	}
}
