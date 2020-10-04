using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum buttonEffect {
	LIGHT,
	DOOR
}

public class ButtonStep : MonoBehaviour {

	public Sprite red, green;

	public buttonEffect[] effects;
	public string[] names;
	public bool[] initialStates;
	public int size;

	void Awake() {
		size = Mathf.Min(effects.Length, Mathf.Min(names.Length, initialStates.Length));
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		GetComponent<SpriteRenderer>().sprite = green;
		for (int i = 0; i < size; i++) {
			GameObject g = GameObject.Find(names[i]);

			if (effects[i] == buttonEffect.LIGHT) {
				g.GetComponent<Beam>().activeCount++;
				if (initialStates[i]) {
					GameObject.Find(names[i]).GetComponent<Beam>().Disable();
				} else {
					GameObject.Find(names[i]).GetComponent<Beam>().Enable();
				}
			} else {
				
			}
		}
	}

	private void OnTriggerExit2D(Collider2D collision) {
		GetComponent<SpriteRenderer>().sprite = red;

		for (int i = 0; i < size; i++) {
			GameObject g = GameObject.Find(names[i]);
			if (effects[i] == buttonEffect.LIGHT) {
				g.GetComponent<Beam>().activeCount--;
				if (g.GetComponent<Beam>().activeCount != 0) { continue; } // Skip this object
				if (!initialStates[i]) {
					GameObject.Find(names[i]).GetComponent<Beam>().Disable();
				} else {
					GameObject.Find(names[i]).GetComponent<Beam>().Enable();
				}
			} else {

			}
		}
	}

}
