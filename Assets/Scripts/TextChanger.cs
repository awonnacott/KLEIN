using UnityEngine;
using System.Collections;

public class TextChanger : MonoBehaviour {
	public TextChanger nextText;
	public bool firstText;
	public bool lastText;
	public string nextLevelName;
	// Use this for initialization
	void Awake () {
		if (firstText) {
			gameObject.SetActive (true);
		} else {
			gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		if (Input.GetKeyDown ("space") || Input.GetKeyDown ("return") || Input.GetKeyDown ("enter")) {
			if (lastText && nextLevelName == "") {
				gameObject.SetActive (false);
			} else if (lastText) {
				Application.LoadLevel(nextLevelName);
			} else {
				gameObject.SetActive (false);
				nextText.gameObject.SetActive (true);
			}
		}
	}
}
