using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour {
	public int scoreToWin;

	public Text countText;
	public Text wText;
	public Text infoText;

	public string nextLevelName;

	public static int count;

	public static float wNow;
	public static float wLastDelta = 0;
	public WController[] WObjects;


	// Awake is called upon creation, before Start, and even if script is not enabled.
	void Awake () {
		wNow = 0;
		count = 0;
	}
	// Start is called upon creation, after Awake, and before the first Update, but only iff script enabled.

	// Update is called once per frame, iff script enabled
	void Update () {
		countText.text = "Count: " + count.ToString ();
		wText.text = "Spin: " + wNow.ToString();
		if (count >= scoreToWin) {
			Application.LoadLevel(nextLevelName);
		}	
	}

	// FixedUpdate is called once per physics, iff script enabled
	void FixedUpdate() {
		float delta = Input.GetAxis ("Switch");
		if (delta != 0) {
			wLastDelta = delta * Time.deltaTime;
			wNow += wLastDelta;
			for(int i=0; i<WObjects.Length; i++) {
				WObjects[i].PlayerUpdate(wNow);
			}
		}
	}
	void OnTriggerEnter(Collider other) {
		wNow -= wLastDelta;
	}
}