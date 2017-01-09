using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour {

	public Button btn;
	public Text scoreText;
	public int finalScore;

	void Start () {

		btn = GetComponent<Button> ();
		finalScore = PlayerPrefs.GetInt("FinalScore");

		scoreText.text = "Final Score: " + finalScore.ToString ();
		Debug.Log (finalScore.ToString ());
		btn.onClick.AddListener(PlayGame);

	}

	void PlayGame(){
		SceneManager.LoadScene ("CodemanGame");
	}
}
