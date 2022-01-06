using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float timer = 60;
    public bool timerRunning = false;

    public Text timerText;

    GameObject gameManager;
    int gameMode;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        gameMode = gameManager.GetComponent<GameManagerScript>().gameMode;
        if (gameMode == 2) timer = 0;
        if (gameMode != 0) timerRunning = true;
        else timerText.text = "";
    }

    void Pause() {
    	timerRunning = false;
    }
    void Resume() {
    	if (gameMode != 0) timerRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerRunning) {
        	if (gameMode == 1) {
        		if (timer > 0) {
		        	timer -= Time.deltaTime;
		        } else {
		        	gameObject.GetComponent<LevelManagerScript>().TimeEnd();
		        	timer = 0.0f;
		        	timerRunning = false;
		        }
        	} else if (gameMode == 2) {
        		timer += Time.deltaTime;
        	}
        	// setting timer text
        	float minutes = Mathf.FloorToInt(timer / 60);
        	float seconds = Mathf.FloorToInt(timer % 60);
        	float miliseconds = Mathf.FloorToInt((timer*100)%100);
        	timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, miliseconds);
        }
        
    }
}
