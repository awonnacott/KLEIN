using UnityEngine;
using System.Collections;

public class WTransformComponent : WComponent {
	public WTransformComponent() {
		interpolate = true;
		exterpolate = false;
	}
	public Vector3 wMinPosition;
	public Vector3 wMaxPosition;
	public override void Awake() {
		if (PlayerController.wNow <= wMin) {
			transform.position = wMinPosition;
		} else if (PlayerController.wNow >= wMin) {
			transform.position = wMaxPosition;
		} else if (PlayerController.wNow > wMin && PlayerController.wNow < wMax) {
				transform.position = wMaxPosition * (PlayerController.wNow - wMin) / (wMax - wMin) + wMinPosition * (wMax - PlayerController.wNow) / (wMax - wMin);
		}
	}
	public override void Activate() {
	}
	public override void Deactivate() {
	}
	public override void WUpdate() {
		if (PlayerController.wNow >= wMin && PlayerController.wNow <= wMax) {
			transform.position = wMaxPosition * (PlayerController.wNow-wMin)/(wMax-wMin) + wMinPosition * (wMax-PlayerController.wNow)/(wMax-wMin);
		} else {
			Debug.Log ("WUpdate called exterpolatively on WTransformComponent.");
		}
	}
}
