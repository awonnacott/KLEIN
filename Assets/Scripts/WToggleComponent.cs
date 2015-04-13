using UnityEngine;
using System.Collections;

public class WToggleComponent : WComponent {
	public WToggleComponent() {
		interpolate = false;
		exterpolate = false;
	}
	public override void Awake() {
		if (PlayerController.wNow >= wMin && PlayerController.wNow <= wMax) {
			gameObject.GetComponent<MeshRenderer> ().enabled = true;
			gameObject.GetComponent<Collider> ().enabled = true;
		} else {
			gameObject.GetComponent<MeshRenderer> ().enabled = false;
			gameObject.GetComponent<Collider> ().enabled = false;
		}
	}
	public override void Activate() {
		gameObject.GetComponent<MeshRenderer>().enabled = true;
		gameObject.GetComponent<Collider>().enabled = true;
	}
	public override void Deactivate() {
		gameObject.GetComponent<MeshRenderer>().enabled = false;
		gameObject.GetComponent<Collider>().enabled = false;
	}
	public override void WUpdate() {
		Debug.Log ("WUpdate called on WToggleComponent. Check exterpolate and interpolate.");
	}
}
