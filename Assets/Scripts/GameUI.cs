using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour {

	public bool playing;
	GameObject pause;

	void Awake() {
		pause = GameObject.Find("Pause");
		playing = false;
		PauseGame();
	}

	public void PauseGame() {
		pause.SetActive(!pause.activeSelf);
		playing = !playing;
	}

	public void Exit() {
		UnityEngine.SceneManagement.SceneManager.LoadScene(1);
	}

}
