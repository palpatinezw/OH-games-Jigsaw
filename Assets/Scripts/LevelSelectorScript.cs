using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class LevelSelectorScript : MonoBehaviour
{
    public string[] levels;
    public Button[] buttons;

    GameObject gameManager;
    public GameObject gameMenu;

    void Start()
    {
        int lvlCount = Math.Min(levels.Length, buttons.Length);
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        
        // Debug.Log(lvlCount);
        for (int i = 0; i < lvlCount; i++) {
        	Debug.Log(i);
        	int temp = i;
        	buttons[i].onClick.AddListener(() => LoadLevel(temp));
        }
    }

    void LoadLevel (int levelId) {
    	// Debug.Log(levels.Length);
    	// Debug.Log(levelId);
    	gameManager.GetComponent<GameManagerScript>().curlevel = levelId;
    	SceneManager.LoadSceneAsync(levels[levelId]);
    }

    public void UpdateButton(int unlockedLevel) {
    	 // = gameManager.GetComponent<GameManagerScript>().levelsPlayed;
    	int lvlCount = Math.Min(levels.Length, buttons.Length);
    	for (int i = 0; i < lvlCount; i++) {
        	if (i > unlockedLevel) {
        		buttons[i].interactable = false;
        	} else {
        		buttons[i].interactable = true;
        	}
        }
        gameMenu.GetComponent<MenuScript>().UpdateButton(unlockedLevel);
    }
}
