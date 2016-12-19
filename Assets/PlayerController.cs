using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;

	private Rigidbody2D rb;
	private Vector2 dest;

	// Use this for initialization
	void Start () {
		speed = 0.4f;
		dest = transform.position;
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
		rb.MovePosition(p);

		if (Input.GetKey (KeyCode.UpArrow) && Valid(Vector2.up)) {
			dest = (Vector2)transform.position + Vector2.up;
		}
			if (Input.GetKey (KeyCode.DownArrow) && Valid(Vector2.down)) {
			dest = (Vector2)transform.position + Vector2.down;
		}
		if (Input.GetKey (KeyCode.LeftArrow) && Valid(Vector2.left)) {
			dest = (Vector2)transform.position + Vector2.left;
		}
		if (Input.GetKey (KeyCode.RightArrow) && Valid(Vector2.right)) {
			dest = (Vector2)transform.position + Vector2.right;
		}

	}

	bool Valid(Vector2 dir) {

		Vector2 pos = transform.position;
		RaycastHit2D hit = Physics2D.Linecast(pos, pos + dir);
		return (hit != null);
	}
}
