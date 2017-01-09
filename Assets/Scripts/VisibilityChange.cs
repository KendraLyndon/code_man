using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityChange : MonoBehaviour {

	public int MinTime = 3;
	public int MaxTime = 10;

	// Use this for initialization
	void Start () {

		foreach (Transform child in transform)
		{
			StartCoroutine (ToggleVisibility (child, false));
		}

	}

	IEnumerator ToggleVisibility(Transform chip, bool act){

		while (true) {

			act = !act;

			chip.gameObject.SetActive (act);

			yield return new WaitForSeconds(Random.Range(MinTime, MaxTime));

		}
	}

}
