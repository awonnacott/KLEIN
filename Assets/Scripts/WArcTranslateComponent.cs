using UnityEngine;
using System.Collections;

public class WArcTranslateComponent : WComponent {
	public WArcTranslateComponent() {
		interpolate = true;
		exterpolate = false;
	}
	public Vector3 wMinPosition;
	public Vector3 wMaxPosition;
	public Vector3 wCenterPosition;
	public override void Awake() {
		if (PlayerController.wNow == wMin) {
			transform.position = wMinPosition;
		} else if (PlayerController.wNow == wMin) {
			transform.position = wMaxPosition;
		} else if (PlayerController.wNow > wMin && PlayerController.wNow < wMax) {
			transform.position = Vector3.Slerp (wMinPosition - wCenterPosition, wMaxPosition - wCenterPosition, (PlayerController.wNow-wMin)/(wMax-wMin)) + wCenterPosition;
		}
	}
	public override void Activate() {
	}
	public override void Deactivate() {
	}
	public override void WUpdate() {
		if (PlayerController.wNow >= wMin && PlayerController.wNow <= wMax) {
			transform.position = Vector3.Slerp (wMinPosition - wCenterPosition, wMaxPosition - wCenterPosition, (PlayerController.wNow-wMin)/(wMax-wMin)) + wCenterPosition;
		} else {
			Debug.Log ("WUpdate called exterpolatively on WTransformComponent.");
		}
	}
}
