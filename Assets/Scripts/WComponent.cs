using UnityEngine;
using System.Collections;

public abstract class WComponent : MonoBehaviour {
	public float wMin;
	public float wMax;
	public bool interpolate;
	public bool exterpolate;
	public abstract void Activate ();
	public abstract void Deactivate ();
	public abstract void WUpdate ();
}
