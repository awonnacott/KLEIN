using UnityEngine;
using System.Collections;

public class WRotateComponent : WComponent {
	public WRotateComponent() {
		interpolate = true;
		exterpolate = false;
	}
	public Vector3 wMinRotation;
	public Vector3 wMaxRotation;
	public override void Awake() {
		if (PlayerController.wNow <= wMin) {
			transform.rotation = Quaternion.Euler (wMinRotation);
		} else if (PlayerController.wNow >= wMax) {
			transform.rotation = Quaternion.Euler(wMaxRotation);
		} else if (PlayerController.wNow > wMin && PlayerController.wNow < wMax) {
			transform.rotation = Quaternion.Slerp(Quaternion.Euler(wMinRotation), Quaternion.Euler(wMaxRotation), (PlayerController.wNow-wMin)/(wMax-wMin));
		}
	}
	public override void Activate() {
	}
	public override void Deactivate() {
	}
	public override void WUpdate() {
		if (PlayerController.wNow >= wMin && PlayerController.wNow <= wMax) {
			transform.rotation = Quaternion.Slerp(Quaternion.Euler(wMinRotation), Quaternion.Euler(wMaxRotation), (PlayerController.wNow-wMin)/(wMax-wMin));
		} else {
			Debug.Log ("WUpdate called exterpolatively on WRotateComponent.");
		}
	}
}
