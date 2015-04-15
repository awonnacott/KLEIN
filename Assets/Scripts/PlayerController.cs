using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour {
	public int scoreToWin;

	public Text countText;
	public Text wText;

	public TextChanger winText;
	public string nextLevelName;

	public static int count = 0;

	public static float wNow = 0;
	public static float wLastDelta = 0;


	// Awake is called upon creation, before Start, and even if script is not enabled.
	void Awake () {
		wNow = 0;
		count = 0;
	}
	// Start is called upon creation, after Awake, and before the first Update, but only iff script enabled.

	// Update is called once per frame, iff script enabled
	void Update () {
		countText.text = "Count: " + count.ToString ();
		wText.text = "w = " + wNow.ToString();
		if (count >= scoreToWin) {
			if (nextLevelName == "") {
				winText.gameObject.SetActive(true);
				nextLevelName = null;
			} else if (nextLevelName != null) {
				wNow = 0;
				Application.LoadLevel(nextLevelName);
			}
		}	
	}

	// FixedUpdate is called once per physics, iff script enabled
	void FixedUpdate() {
		float delta = Input.GetAxis ("Switch");
		if (delta != 0) {
			wLastDelta = delta * Time.deltaTime;
			wNow += wLastDelta;
		}
	}
	void OnTriggerEnter(Collider other) {
		wNow -= wLastDelta;
	}
}