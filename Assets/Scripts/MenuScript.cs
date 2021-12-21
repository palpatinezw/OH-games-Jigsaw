using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MenuScript : MonoBehaviour
{
    public string[] toActive;
    public Button[] buttons;

    public int[] gameMode;
    public Button[] gameModeSelection;
    public int[] gameModeLevelReq;

    GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        setActive("HomeScreen");
        gameManager = GameObject.FindGameObjectWithTag("GameController");

        int btncount = Math.Min(toActive.Length, buttons.Length);
        for (int i = 0; i < btncount; i++) {
        	string temp = toActive[i];
        	buttons[i].onClick.AddListener(() => setActive(temp));
        }

        int gameModeCount = Math.Min(gameMode.Length, gameModeSelection.Length);
        for (int i = 0; i < gameModeCount; i++) {
        	int temp = gameMode[i];
        	gameModeSelection[i].onClick.AddListener(() => gameManager.GetComponent<GameManagerScript>().SetGameMode(temp));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setActive(string curactive) {
    	foreach(Transform child in transform) {
    		GameObject cur = child.gameObject;
    		if (cur.name == curactive) cur.SetActive(true);
    		else cur.SetActive(false);
    	}
    }

    public void UpdateButton(int unlockedLevel) {
    	 // = gameManager.GetComponent<GameManagerScript>().levelsPlayed;
    	int gameModeCount = Math.Min(gameMode.Length, gameModeSelection.Length);
    	for (int i = 0; i < gameModeCount; i++) {
    		Debug.Log("Update " + unlockedLevel);
        	if (gameModeLevelReq[i] > unlockedLevel) {
        		gameModeSelection[i].interactable = false;
        	} else {
        		gameModeSelection[i].interactable = true;
        	}
        }
    }
}
