using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

	public Button btn;

	void Start () {
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(RestartGame);
	}

	void RestartGame(){
		SceneManager.LoadScene ("CodemanGame");
	}
}
