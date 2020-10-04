using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagScript : MonoBehaviour {

	public Sprite green;

	public void ChangeState() {
		Destroy(GetComponent<BoxCollider2D>());
		GetComponent<SpriteRenderer>().sprite = green;
		GetComponent<AudioSource>().Play();
	}

}
