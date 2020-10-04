using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {
	private void Awake() {
		gameObject.GetComponent<Camera>().targetDisplay = 0;
	}

	public void DestroyThis() {
		Destroy(gameObject);
	}
}
