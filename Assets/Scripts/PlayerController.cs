using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour {
	public int scoreToWin;

	public Text countText;
	public Text wText;
	public Text infoText;

	public static int count = 0;

	public static float wNow = 0;
	public static float wLastDelta = 0;
	public WController[] WObjects;

	// Update is called once per frame
	void Update () {
		countText.text = "Count: " + count.ToString ();
		wText.text = "Spin: " + wNow.ToString();
		if (count >= scoreToWin) {
			Application.LoadLevel("WinScreen");
		}	
	}

	// FixedUpdate is called once per physics
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