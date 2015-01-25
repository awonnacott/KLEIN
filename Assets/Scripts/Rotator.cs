﻿using UnityEngine;
using System.Collections;

public class Rotator : PickupController {
	public Vector3 rotationSpeed;
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (rotationSpeed * Time.deltaTime);
	}
}
