using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugController : MonoBehaviour {

	public float speed;
	public Transform[] waypoints;

	private Rigidbody2D rb;
	private int cur;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
		cur = 0;
	}

	// Update is called once per frame
	void FixedUpdate () {

		if (transform.position != waypoints[cur].position) {
			Vector2 p = Vector2.MoveTowards(transform.position,
				waypoints[cur].position,
				speed);
			rb.MovePosition(p);
		}
		else cur = (cur + 1) % waypoints.Length;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Maze")) {
			other.enabled = false;
		} 
//		else if (other.CompareTag ("noLives")) {
//			Destroy (other.gameObject);
//		}
	}
		
}
