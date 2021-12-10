using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagerScript : MonoBehaviour
{
    public int noOfPieces;

    public Text coverScreenText;
    public GameObject coverScreenImage;

    private bool paused = false;

    void Start() {
        //
    }

    void Update() {
    	if (noOfPieces == 0) GameWin();

        // broadcast functions that dont have in game UI yet
        if (Input.GetKeyDown("r")) BroadcastMessage("Reset");
        if (Input.GetKeyDown("p")) Pause();
        if (Input.GetKeyDown("c")) Resume();
    }
    // noOfPieces counts number of pieces out of position
    
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
        BroadcastMessage("Pause");
    }
    public void GameWin() {
        // when all pieces are in position
        gameObject.GetComponent<TimerScript>().timerRunning = false;
        float finalTime = gameObject.GetComponent<TimerScript>().timer;
        ShowCover("Congrats!");
        BroadcastMessage("Pause");
    }

    public void Pause() {
        if (paused) return;
        // for when timer runs out
        paused = true;
        ShowCover("Game Paused");
        BroadcastMessage("Pause");
    }
    public void Resume() {
        if (!paused) return;
        // for when timer runs out
        paused = false;
        HideCover();
        BroadcastMessage("Resume");
    }

    void ShowCover(string DisplayText) {
        Debug.Log("Show Cover");
        coverScreenText.text = DisplayText;
        coverScreenImage.GetComponent<CanvasGroup>().alpha = 1.0f;
    }
    void HideCover() {
        coverScreenImage.GetComponent<CanvasGroup>().alpha = 0.0f;
    }
}
