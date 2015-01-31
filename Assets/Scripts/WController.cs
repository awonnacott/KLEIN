using UnityEngine;
using System.Collections;

public class WController : MonoBehaviour {
	public float minW;
	public float maxW;
	public float minWBorder;
	public float maxWBorder;
	public Vector3 minW_V;
	public Vector3 maxW_V;
	protected bool gone = false;

	void Start() {
		PlayerUpdate (0);
	}

	public void PlayerUpdate(float wNow) {
		Debug.Log ("SpinController PlayerUpdate");
		Debug.Log (transform.position.GetType());
		if (PlayerController.wNow < maxW && PlayerController.wNow > minW && !gone) {
			gameObject.SetActive (true);
			transform.position = maxW_V * (wNow-minW)/(maxW-minW) + minW_V * (maxW-wNow)/(maxW-minW);
		} else if (PlayerController.wNow <= maxW+maxWBorder && PlayerController.wNow >= maxW) {
			gameObject.SetActive (true);
			transform.position = maxW_V;
		} else if (PlayerController.wNow <= minW && PlayerController.wNow >= minW-minWBorder) {
			gameObject.SetActive (true);
			transform.position = minW_V;
		} else {
			gameObject.SetActive (false);
		}
	}
}
