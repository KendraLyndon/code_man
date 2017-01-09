using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour {

		public Button btn;

		void Start () {
			Button btn = GetComponent<Button>();
			btn.onClick.AddListener(PlayGame);
		}

		void PlayGame(){
			SceneManager.LoadScene ("CodemanGame");
		}
}
