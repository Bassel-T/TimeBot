using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour {

	List<GameObject> children;
	BoxCollider2D bc;
	public bool startDisabled;
	public int activeCount;

	// Start is called before the first frame update
	void Awake() {
		bc = GetComponent<BoxCollider2D>();
		children = new List<GameObject>();
		int childCount = transform.childCount;
		for (int i = 0; i < childCount; i++) {
			children.Add(transform.GetChild(i).gameObject);
		}

		if (startDisabled) {
			Disable();
		}
	}

	public void Disable() {
		foreach (GameObject g in children) {
			g.GetComponent<SpriteRenderer>().enabled = false;
		}
		bc.enabled = false;
	}

	public void Enable() {
		foreach (GameObject g in children) {
			g.GetComponent<SpriteRenderer>().enabled = true;
		}
		bc.enabled = true;
	}
}
