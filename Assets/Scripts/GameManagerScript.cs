using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public int gameMode = -1; // 0 is no timer mode, 1 is timer mode, more modes in future
    public int curlevel = -1; 
    public int levelsPlayed = 0;

    GameObject levelSelector;

    // public int curLevel;

	// Access this using gameControllerObj = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    void Awake() {
	    GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("GameController");
	    if (gameObjects.Length > 1) Destroy(gameObject);

	    DontDestroyOnLoad(transform.gameObject);
	}

    // Start is called before the first frame update
    void Start() {
    	levelSelector = GameObject.Find("LevelSelector");
        levelsPlayed = PlayerPrefs.GetInt("LevelsPlayed", 0);
        levelSelector.GetComponent<LevelSelectorScript>().UpdateButton(levelsPlayed);
    }

    void Update() {
    	if (Input.GetKeyDown("0")) {
    		PlayerPrefs.SetInt("LevelsPlayed", 0);
    		Debug.Log("LevelsPlayed RESET");
    	}
    }

    public void LevelComplete () {
    	if (curlevel == levelsPlayed) {
    		levelsPlayed++;
    		PlayerPrefs.SetInt("LevelsPlayed", levelsPlayed);
    		levelSelector.GetComponent<LevelSelectorScript>().UpdateButton(levelsPlayed);
    	}
    	curlevel = -1;
    }

    public void SetGameMode(int newGameMode) {
    	gameMode = newGameMode;
    }
}
