using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public Canvas menu;
	public Button start;
	public Button exit;
	public Button startGame;
	public Button entry;
	public Animator Anim;
	public AudioClip aud;


	public Image title;
	public Image startText;
	public Image exitText;

	// Use this for initialization
	void Start () {
		menu.GetComponent <Canvas> ();
		start.GetComponent <Button> ();
		exit.GetComponent <Button> ();
		entry.GetComponent <Button> ();
		Anim.GetComponent <Animator> ();

	}

	/*public void pressStart () {
		Anim.Play ("TitleMove");
	}*/

	public void pressEntry () {
		Anim.Play ("Show");
	}

	/*public void startButton () {
		Anim.Play ("MoveLeft");
	}*/

	public void pressStart () {
		SceneManager.LoadScene ("LevelInfo");
	}

	public void pressExit () {
		Application.Quit ();
	}
}
