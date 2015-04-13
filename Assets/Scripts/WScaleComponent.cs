using UnityEngine;
using System.Collections;

public class WScaleComponent : WComponent {
	public WScaleComponent() {
		interpolate = true;
		exterpolate = false;
	}
	public Vector3 wMinScale;
	public Vector3 wMaxScale;
	public override void Awake() {
		if (PlayerController.wNow <= wMin) {
			transform.localScale = wMinScale;
		} else if (PlayerController.wNow >= wMin) {
			transform.localScale = wMaxScale;
		} else if (PlayerController.wNow > wMin && PlayerController.wNow < wMax) {
			transform.localScale = wMaxScale * (PlayerController.wNow - wMin) / (wMax - wMin) + wMinScale * (wMax - PlayerController.wNow) / (wMax - wMin);
		}
	}
	public override void Activate() {
	}
	public override void Deactivate() {
	}
	public override void WUpdate() {
		if (PlayerController.wNow >= wMin && PlayerController.wNow <= wMax) {
			transform.localScale = wMaxScale * (PlayerController.wNow-wMin)/(wMax-wMin) + wMinScale * (wMax-PlayerController.wNow)/(wMax-wMin);
		} else {
			Debug.Log ("WUpdate called exterpolatively on WScaleComponent.");
		}
	}
}
