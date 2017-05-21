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
	public Animator Anim;

	public Image title;
	public Image startText;
	public Image exitText;

	// Use this for initialization
	void Start () {
		menu.GetComponent <Canvas> ();
		start.GetComponent <Button> ();
		exit.GetComponent <Button> ();
		Anim.GetComponent <Animator> ();
	}

	public void pressStart () {
		Anim.Play ("TitleMove");
	}
	/*
	public void scrollUp () {
		Anim.Play ("MoveUp");
	}

	public void startButton () {
		Anim.Play ("MoveLeft");
	}*/

	public void pressStartGame () {
		SceneManager.LoadScene (1);
	}

	public void pressExit () {
		Application.Quit ();
	}
}
