using UnityEngine;
using System.Collections;

public class PickupController : WController {
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			gameObject.SetActive(false);
			PlayerController.count++;
		}
	}
}
