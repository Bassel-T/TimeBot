using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	AudioSource[] sources;
	bool looped = true;

	// Start is called before the first frame update
	void Awake() {
		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene() == UnityEngine.SceneManagement.SceneManager.GetSceneAt(0)) {
			UnityEngine.SceneManagement.SceneManager.LoadScene(1);
		}
		sources = GetComponents<AudioSource>();
		StartCoroutine(MusicLoop());
		DontDestroyOnLoad(this.gameObject);
	}

	IEnumerator MusicLoop() {
		float length = sources[0].clip.length + 0.25f;
		while (true) {
			yield return new WaitForSecondsRealtime(length);
			byte playing = (byte)(Random.Range(1, 15));
			if ((playing & 1) == 1) {
				sources[1].volume = 1;
			} else {
				sources[1].volume = 0;
			}

			if ((playing & 2) == 2) {
				sources[3].volume = 1;
			} else {
				sources[3].volume = 0;
			}

			if ((playing & 4) == 4) {
				sources[4].volume = 1;
			} else {
				sources[4].volume = 0;
			}
		}
	}

	public void StopAll() {
		foreach (AudioSource a in sources) {
			a.Stop();
		}

		sources[5].Play();
	}

}
