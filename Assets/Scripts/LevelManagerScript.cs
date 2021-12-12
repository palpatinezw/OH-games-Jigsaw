using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LevelManagerScript : MonoBehaviour
{
    public int noOfPieces;

    public Text coverScreenText;
    public GameObject coverScreen;
    public GameObject resumeButton;

    public Button[] buttons;
    public string[] btnStrs;

    private bool paused = false;

    void Start() {
        coverScreen.SetActive(false);
        resumeButton.SetActive(false);
        
        int btncount = Math.Min(btnStrs.Length, buttons.Length);
        for (int i = 0; i < btncount; i++) {
            string temp = btnStrs[i];
            buttons[i].onClick.AddListener(() => BtnClick(temp));
        }
    }

    void Update() {
    	if (noOfPieces == 0 && !paused) GameWin();

        // broadcast functions that dont have in game UI yet
        if (Input.GetKeyDown("r")) BroadcastMessage("Reset");
        if (Input.GetKeyDown("p")) BroadcastMessage("Pause");
        if (Input.GetKeyDown("c")) BroadcastMessage("Resume");
    }
    // noOfPieces counts number of pieces out of position

    void BtnClick(string str) {
        BroadcastMessage(str);
    }
    
    public void SetAnswerCorrect() {
    	noOfPieces--;
        Debug.Log("Piece added : " + noOfPieces);
    }
    public void SetAnswerWrong() {
    	noOfPieces++;
        Debug.Log("Piece removed : " + noOfPieces);
    }

    public void TimeEnd() {
        // for when timer runs out
        ShowCover("Time's Up!");
        paused = true;
        BroadcastMessage("Pause");
    }
    public void GameWin() {
        // when all pieces are in position
        gameObject.GetComponent<TimerScript>().timerRunning = false;
        float finalTime = gameObject.GetComponent<TimerScript>().timer;
        ShowCover("Congrats!");
        paused = true;
        BroadcastMessage("Pause");
    }

    public void Pause() {
        if (paused) return;
        
        resumeButton.SetActive(true);
        paused = true;
        ShowCover("Game Paused");
    }
    public void Resume() {
        if (!paused) return;
        resumeButton.SetActive(false);
        paused = false;
        HideCover();
    }

    void ShowCover(string DisplayText) {
        Debug.Log("Show Cover");
        coverScreenText.text = DisplayText;
        coverScreen.SetActive(true);
    }
    void HideCover() {
        coverScreen.SetActive(false);
    }
}
