using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoSingleton <BossSpawner> {
	public GameObject monster;
	public Vector3 spawnValues;
	public float startWait;
	public float spawnWait;
	public float waveWait;
	public int monsterCount;

	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Initialize()
	{
		StartCoroutine (SpawnBoss ());
	}

	IEnumerator SpawnBoss ()
	{
		while (GameControllerNextLevel.Instance.numOfCollect >= GameControllerNextLevel.Instance.goalOfCollect) {
			//time break before the hazard
			yield return new WaitForSeconds (Random.Range (startWait, startWait + spawnWait * monsterCount));
		 
			Vector3 spawnPosition = new Vector3 (spawnValues.x, Random.Range (spawnValues.y - 5, spawnValues.y + 3.5f), Random.Range (-spawnValues.z, spawnValues.z));
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (monster, spawnPosition, spawnRotation);
			StopCoroutine (SpawnBoss ());
		}
	}
}
