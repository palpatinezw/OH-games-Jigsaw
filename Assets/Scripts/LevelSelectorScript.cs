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

    void Start()
    {
        int lvlCount = Math.Min(levels.Length, buttons.Length);
        Debug.Log(lvlCount);
        for (int i = 0; i < lvlCount; i++) {
        	Debug.Log(i);
        	int temp = i;
        	buttons[i].onClick.AddListener(() => LoadLevel(temp));
        }
    }

    void LoadLevel (int levelId) {
    	Debug.Log(levels.Length);
    	Debug.Log(levelId);
    	SceneManager.LoadSceneAsync(levels[levelId]);
    }
}
