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

	/*void Start() {
		PlayerUpdate (0);
	}*/

	public void Awake() {
		wComponents = gameObject.GetComponents<WComponent> ();
	}

	public void FixedUpdate() {
		foreach (WComponent wComponent in wComponents) {
			if ((PlayerController.wNow == wComponent.wMin && PlayerController.wLastDelta > 0) || (PlayerController.wNow == wComponent.wMax && PlayerController.wLastDelta < 0)) {
				wComponent.Activate();
			} else if ((PlayerController.wNow == wComponent.wMax && PlayerController.wLastDelta > 0) || (PlayerController.wNow == wComponent.wMin && PlayerController.wLastDelta < 0)) {
				wComponent.Deactivate();
			} else if ((PlayerController.wNow < wComponent.wMax && PlayerController.wNow > wComponent.wMin && wComponent.interpolate) || ((PlayerController.wNow > wComponent.wMax || PlayerController.wNow < wComponent.wMin) && wComponent.exterpolate)) {
				wComponent.WUpdate ();
			}
		}

		if (PlayerController.wNow < maxW && PlayerController.wNow > minW) {
			//gameObject.SetActive (true);
			gameObject.GetComponent<MeshRenderer>().enabled = true;
			gameObject.GetComponent<Collider>().enabled = true;

			transform.position = maxW_V * (PlayerController.wNow-minW)/(maxW-minW) + minW_V * (maxW-PlayerController.wNow)/(maxW-minW);
		} else if (PlayerController.wNow <= maxW+maxWBorder && PlayerController.wNow >= maxW) {
			//gameObject.SetActive (true);
			gameObject.GetComponent<MeshRenderer>().enabled = true;
			gameObject.GetComponent<Collider>().enabled = true;
			transform.position = maxW_V;
		} else if (PlayerController.wNow <= minW && PlayerController.wNow >= minW-minWBorder) {
			//gameObject.SetActive (true);
			gameObject.GetComponent<MeshRenderer>().enabled = true;
			gameObject.GetComponent<Collider>().enabled = true;
			transform.position = minW_V;
		} else {
			//gameObject.SetActive (false);
			gameObject.GetComponent<MeshRenderer>().enabled = false;
			gameObject.GetComponent<Collider>().enabled = false;
		}

	}
}
