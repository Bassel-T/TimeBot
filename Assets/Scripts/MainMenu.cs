using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
	
	public void StartGame() {
		UnityEngine.SceneManagement.SceneManager.LoadScene(2);
	}

	public void Exit() {
		Application.Quit();
	}

}
