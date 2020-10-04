using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	// In charge of the respawn point
	public List<Vector2> spawnpoints;
	public int currLevel;
	public List<string> stageNames;
	public int level;

	void Awake() {
		// Levels start at ONE, not ZERO
		level = 1;
		spawnpoints = new List<Vector2>() {
			Vector2.zero,
			new Vector2(-10, 0),
			new Vector2(25, 1.5f),
			new Vector2(43, 10.5f),
			new Vector2(59, -17.5f),
			new Vector2(77, -17.5f),
			new Vector2(96, -17.5f),
			new Vector2(122, -17.5f),
			new Vector2(151, -17.5f),
			new Vector2(176, -17.5f),
			new Vector2(200, -17.5f),
		};
		stageNames = new List<string>() {
			"",
			"Stage 1: Tutorial Stage",
			"Stage 2: I Don't Do Wet",
			"Stage 3: Leap of Faith",
			"Stage 4: Laying Low",
			"Stage 5: Beaming With Anger",
			"Stage 6: What Does This Do?",
			"Stage 7: The Journey Continues",
			"Stage 8: Think Before You Do",
			"Stage 9: Finale - RUN"
		};
	}

	public void NextLevel() {
		level++;
		GameObject.Find("StageName").GetComponent<Text>().text = stageNames[level];
	}
}
