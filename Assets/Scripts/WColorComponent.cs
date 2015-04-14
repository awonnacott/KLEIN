using UnityEngine;
using System.Collections;

public class WColorComponent : WComponent {
	public WColorComponent() {
		interpolate = true;
		exterpolate = false;
	}
	private Material material;
	public Color wMinColor;
	public Color wMaxColor;
	public override void Awake() {
		material = gameObject.GetComponent<MeshRenderer>().material;
		if (PlayerController.wNow < wMin) {
			material.SetColor("_Color", wMinColor);
		} else if (PlayerController.wNow > wMax) {
			material.SetColor("_Color", wMaxColor);
		} else if (PlayerController.wNow >= wMin && PlayerController.wNow <= wMax) {
			material.SetColor("_Color", Color.Lerp(wMinColor, wMaxColor, (PlayerController.wNow-wMin)/(wMax-wMin)));
		}
	}
	public override void Activate() {
	}
	public override void Deactivate() {
	}
	public override void WUpdate() {
		if (PlayerController.wNow >= wMin && PlayerController.wNow <= wMax) {
			material.SetColor("_Color", Color.Lerp(wMinColor, wMaxColor, (PlayerController.wNow-wMin)/(wMax-wMin)));
		} else {
			Debug.Log ("WUpdate called exterpolatively on WRotateComponent.");
		}
	}
}
