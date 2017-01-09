using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float speed;
	public int score;
	public Text scoreText;
	public Text livesText;

	private Rigidbody2D rb;
	private GameObject bitParent;
	private Vector2 dest;
	private int lives;

	// Use this for initialization
	void Start () {
		speed = 0.2f;
		score = 0;
		lives = 2;
		SetScoreText ();
		SetLivesText ();
		dest = transform.position;
		rb = gameObject.GetComponent<Rigidbody2D> ();
		bitParent = GameObject.FindWithTag("BitParent");
	}

	void FixedUpdate () {

		if (Input.GetKey (KeyCode.UpArrow)) {
			dest = (Vector2)transform.position + Vector2.up;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			dest = (Vector2)transform.position + Vector2.down;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			dest = (Vector2)transform.position + Vector2.left;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			dest = (Vector2)transform.position + Vector2.right;
		}

		Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
		rb.MovePosition(p);
		Animate ();

		if (bitParent.transform.childCount == 0) {
			saveFinalScore ();
			SceneManager.LoadScene ("WinScene");
		}

	}

	void Animate(){
		Vector2 dir = dest - (Vector2)transform.position;
		GetComponent<Animator>().SetFloat("DirX", dir.x);
		GetComponent<Animator>().SetFloat("DirY", dir.y);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Pickup")) {
			
			Destroy (other.gameObject);

		} else if (other.CompareTag ("Microchip")) {

			other.gameObject.SetActive (false);
			score = score + 100;
			SetScoreText ();

		} else if (other.CompareTag ("Bug")) {
			
			if (lives > 0) {
				loseLife ();

			} else if (lives == 0){

				SceneManager.LoadScene ("GameOver");
			}
		}
	}

	void loseLife(){
		lives -= 1;
		SetLivesText ();
	}

	void SetScoreText(){
		scoreText.text = "score: " + score.ToString ();
	}

	void SetLivesText(){
		livesText.text = "lives: " + lives.ToString ();
	}

	void saveFinalScore() {
		PlayerPrefs.SetInt("FinalScore",score); 
	}

}
