using UnityEngine;
using System.Collections;

public class WController : MonoBehaviour {
	public float minW;
	public float maxW;
	public Vector3 minW_V;
	public Vector3 maxW_V;
	protected bool gone = false;

	void Start() {
		PlayerUpdate (0);
	}

	public void PlayerUpdate(float wNow) {
		Debug.Log ("SpinController PlayerUpdate");
		Debug.Log (transform.position.GetType());
		if (PlayerController.wNow <= maxW && PlayerController.wNow >= minW && !gone) {
			gameObject.SetActive (true);
			transform.position = minW_V * (wNow-minW)/(maxW-minW) + maxW_V * (maxW-wNow)/(maxW-minW) ;
		} else {
			gameObject.SetActive (false);
		}
	}
}
