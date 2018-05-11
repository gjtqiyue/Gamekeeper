using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InfoManager : MonoBehaviour {

	public Canvas intro;
	public Animator anim;
	public Image postImage;
	public Image nextImage;
	public Image startImage;
	public Text introText;
	public Button startButton;
	public Button nextButton;

	private bool finish = false;

	void Start () {
		intro.GetComponent <Canvas> ();
		anim.GetComponent <Animator> ();
		postImage.GetComponent <Image> ();
		nextImage.GetComponent <Image> ();
		startImage.GetComponent <Image> ();
		startButton.GetComponent <Button> ();
		nextButton.GetComponent <Button> ();
		introText.GetComponent <Text> ();

		introText.enabled = true;
		postImage.enabled = true;
		nextImage.enabled = true;
	}
		

	public void pressNext () {
		if (finish == false) {
			Debug.Log ("press");
			introText.enabled = false;
			anim.Play ("PostMove");
			finish = true;
		} else {
			anim.Play ("StartMove");
			nextImage.enabled = false;
		}
	}
		
		
	public void pressStart () {
		SceneManager.LoadScene ("MainScene");
	}


}
