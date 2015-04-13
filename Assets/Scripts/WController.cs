using UnityEngine;
using System.Collections;

public class WController : MonoBehaviour {
	public float minW;
	public float maxW;
	public float minWBorder;
	public float maxWBorder;
	public Vector3 minW_V;
	public Vector3 maxW_V;
	public WComponent[] wComponents;

	public void Awake() {
		wComponents = gameObject.GetComponents<WComponent> ();
		//WComponent#Awake() called on all as well
	}

	public void FixedUpdate() {
		foreach (WComponent wComponent in wComponents) {
			if ((PlayerController.wNow >= wComponent.wMin && PlayerController.wLastDelta >= PlayerController.wNow - wComponent.wMin) || (PlayerController.wNow <= wComponent.wMax && PlayerController.wLastDelta <= PlayerController.wNow - wComponent.wMax)) {
				wComponent.Activate();
			} else if ((PlayerController.wNow >= wComponent.wMax && PlayerController.wLastDelta >= PlayerController.wNow - wComponent.wMax) || (PlayerController.wNow <= wComponent.wMin && PlayerController.wLastDelta <= PlayerController.wNow - wComponent.wMin)) {
				wComponent.Deactivate();
			} else if ((PlayerController.wNow < wComponent.wMax && PlayerController.wNow > wComponent.wMin && wComponent.GetInterpolate()) || ((PlayerController.wNow > wComponent.wMax || PlayerController.wNow < wComponent.wMin) && wComponent.GetExterpolate())) {
				wComponent.WUpdate ();
			}
		}
	}
}
