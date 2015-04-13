using UnityEngine;
using System.Collections;

public abstract class WComponent : MonoBehaviour {
	public float wMin;
	public float wMax;
	protected bool interpolate;
	public bool GetInterpolate() {
		return interpolate;
	}
	protected bool exterpolate;
	public bool GetExterpolate() {
		return exterpolate;
	}
	public abstract void Awake ();
	public abstract void Activate ();
	public abstract void Deactivate ();
	public abstract void WUpdate ();
}
