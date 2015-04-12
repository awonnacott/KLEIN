using UnityEngine;
using System.Collections;

public class WToggleComponent : WComponent {
	public bool interpolate = false;
	public bool exterpolate = false;
	public override void Activate() {
	}
	public override void Deactivate() {
	}
	public override void WUpdate() {
		Debug.Log ("WUpdate called on WToggleComponent.");
	}
}
