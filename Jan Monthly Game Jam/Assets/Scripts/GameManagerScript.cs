using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	public Animator anim;

	public int player1Score;
	public int player2Score;
	public int winCondition = 3;
	public float time = 10f;
	public bool gameStart = false;
	public string finalResult = "";

	public Text timerText;
	public Text instructionText;
	public Text resultText;
	public Text winText;
	public Text player1ScoreText;
	public Text player2ScoreText;
	public Button startButton;

	Player1Script playerInfo1;
	Player2Script playerInfo2;

	private bool allDone = false;
	private bool firstStage = false;
	private bool secondStage = false;
	private bool finalStage = false;
	private bool addScore = false;
	private float timeRemain;
	private string result1;
	private string result2;

	public readonly float waitBeforeRot = 1f; // for player1 and player2, the seconds wait before rotate the card
	public readonly float readAfterRot = 2f; // for player1 and player2, the seconds wait after rotate the card

	void Start () {
		playerInfo1 = player1.GetComponent <Player1Script> ();
		playerInfo2 = player2.GetComponent <Player2Script> ();
		anim = GetComponent <Animator> ();

		//initialize ();
	}

	void Update () {
		if (Input.anyKeyDown && gameStart == false) {
			fadeMenu ();
			StartCoroutine (TimeControlBetweenTwoInputs ());

		}

		if (gameStart == true) {                                          // if the game starts
			player1ScoreText.text = ("Player1:" + player1Score);
			player2ScoreText.text = ("Player2:" + player2Score);

			// The first stage
			if (firstStage == true) {
				instructionText.text = "Make a select of what you want to play first";
				// make sure both players select something in the end
				if (playerInfo1.covSelectDone == true && playerInfo2.covSelectDone == true) {
					allDone = true;
				} 
			}

			// The Second stage
			if (secondStage == true) {
				allDone = false;
				if (timerText.enabled == false) {
					Debug.Log ("enable timer");
					timerText.enabled = true;
					instructionText.text = "Now consider your real play";
				}
				timerText.text = string.Format ("{0:0}", timeRemain);
				timeRemain = timeRemain - Time.deltaTime;
				if (timeRemain < 0.1) {
					instructionText.enabled = false;
					timerText.text = "Rock Paper scissors !";

					secondStage = false;
					finalStage = true;
				}
			}

			// The Final stage
			if (finalStage == true) {
				result1 = playerInfo1.finalPlay;           //get the final result of player1
				result2 = playerInfo2.finalPlay;           //get the final result of player1
				finalResult = Judge (result1, result2);    //judge
				StartCoroutine (ShowTheResult ());         //wait and show the winner, then initialize if game is not over

			}

			if (Input.anyKeyDown && gameStart == true && winText.enabled == true) {         // input any key to go back to menu when the game is finished
				Debug.Log ("show menu");
				showMenu ();
			}
		}
	}

	public string Judge (string result1, string result2) {
		if (result1.Equals ("Rock")) {
			if (result2.Equals ("Scissor"))
				return "Player1";
			else if (result2.Equals ("Paper"))
				return "Player2";
			else
				return "Draw";
		}

		if (result1.Equals ("Paper")) {
			if (result2.Equals ("Rock"))
				return "Player1";
			else if (result2.Equals ("Scissor"))
				return "Player2";
			else
				return "Draw";
		}

		if (result1.Equals ("Scissor")) {
			if (result2.Equals ("Paper"))
				return "Player1";
			else if (result2.Equals ("Rock"))
				return "Player2";
			else
				return "Draw";
		}
		return "No result";
	}

	IEnumerator ShowTheResult () {
		yield return new WaitForSeconds (2);
		timerText.enabled = false;
		resultText.enabled = true;

		//record score
		if (finalResult.Equals ("Player1")) {

			resultText.text = "Player1 won this round!";
			if (addScore == false) {
				player1Score++;
				addScore = true;
			}

			finalStage = false;
		} 
		else if (finalResult.Equals ("Player2")) {

			resultText.text = "Player2 won this round!";
			if (addScore == false) {
				player2Score++;
				addScore = true;
			}

			finalStage = false;
		} 
		else if (finalResult.Equals ("Draw")) {
			resultText.text = "It's a draw";
			finalStage = false;
		}
			
		yield return new WaitForSeconds (3);

		if (player1Score < winCondition && player2Score < winCondition) {
			initialize ();
		}

		if (player1Score >= winCondition || player2Score >= winCondition) {
			Win ();
		}
	}

	public void initialize () {
		Debug.Log ("initialize");
		instructionText.enabled = true;
		firstStage = true;
		resultText.enabled = false;
		winText.enabled = false;
		allDone = false;
		secondStage = false;
		timerText.enabled = false;
		addScore = false;
		//playerInfo1.Reset ();
		//playerInfo2.Reset ();
		playerInfo1.Reset ();
		playerInfo2.Reset ();
		timeRemain = time;
	}

	public void Win () {
		resultText.enabled = false;

		if (player1Score >= winCondition) {
			winText.text = "Player1 won!";
			winText.enabled = true;

		}

		if (player2Score >= winCondition) {
			winText.text = "Player2 won!";
			winText.enabled = true;
		}
	}

	public void showMenu () {
		// play some animation to show the menu
		//anim.Play ("showMenu");
		anim.SetBool ("gameStart", false);
		StartCoroutine (TimeControlBetweenTwoInputs ());
		gameStart = false;
	}

	public void fadeMenu () {
		
		player1Score = 0;
		player2Score = 0;

		// play some animation to fade the menu
		//anim.Play ("fadeMenu");
		anim.SetBool ("gameStart", true);

		initialize ();
	}

	IEnumerator TimeControlBetweenTwoInputs () {
		yield return new WaitForSeconds (1);
		if (gameStart == true)
			gameStart = false;
		if (gameStart == false)
			gameStart = true;
	}

	public bool GetAllDone () {
		return allDone;
	}

	public bool GetFirstStage () {
		return firstStage;
	}

	public void CloseFirstStage () {
		firstStage = false;
	}

	public void OpenSecondStage () {
		secondStage = true;
	}
		
	public bool GetSecondStage () {
		return secondStage;
	}

	public bool GetFinalStage () {
		return finalStage;
	}
}
