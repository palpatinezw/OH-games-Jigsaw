using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float timer = 60;
    public bool timerRunning = false;

    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        timerRunning = true;
    }

    void Pause() {
    	timerRunning = false;
    }
    void Resume() {
    	timerRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerRunning) {
        	if (timer > 0) {
	        	timer -= Time.deltaTime;

	        	// setting timer text
	        	float minutes = Mathf.FloorToInt(timer / 60);
	        	float seconds = Mathf.FloorToInt(timer % 60);
	        	timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
	        } else {
	        	gameObject.GetComponent<LevelManagerScript>().TimeEnd();
	        	timer = 0;
	        	timerRunning = false;
	        }
        }
        
    }
}
