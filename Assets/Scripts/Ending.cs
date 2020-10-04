using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour {

	float yInit;
	float x;

	// Start is called before the first frame update
	void Start() {
		yInit = transform.position.y;
		x = transform.position.x;
	}

	// Update is called once per frame
	void Update() {
		transform.position = new Vector2(x, yInit + 0.3f * Mathf.Sin(Time.frameCount / 60f)) ;
	}
}
