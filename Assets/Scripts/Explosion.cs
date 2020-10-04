using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	Animator anim;

	// Start is called before the first frame update
	void Awake() {
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update() {
		if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f) {
			transform.parent.GetComponent<SpriteRenderer>().enabled = false;
		}
		if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1) {
			Destroy(transform.parent.gameObject);
		}
	}
}
