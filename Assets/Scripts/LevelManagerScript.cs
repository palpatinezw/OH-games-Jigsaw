using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
    public int noOfPieces;
    public int LevelNo; //This MUST be set to the correct id as under LevelSelectorScript

    private bool paused = false;

    public GameObject UICanvas;

    GameObject gameManager;

    void Start() {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        // gameManager = gameManagers[0];
    }

    void Update() {
    	if (noOfPieces == 0 && !paused) BroadcastMessage("GameWin");

        // broadcast functions that dont have in game UI yet
        if (Input.GetKeyDown("r")) BroadcastMessage("Reset");
        if (Input.GetKeyDown("p")) BroadcastMessage("Pause");
        if (Input.GetKeyDown("c")) BroadcastMessage("Resume");
    }
    // noOfPieces counts number of pieces out of position

    public void BtnClick(string str) {
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
        paused = true;
        BroadcastMessage("Pause");

        UICanvas.GetComponent<LevelUIScript>().TimeEnd();
    }
    public void GameWin() {
        // when all pieces are in position
        gameObject.GetComponent<TimerScript>().timerRunning = false;
        float finalTime = gameObject.GetComponent<TimerScript>().timer;
        paused = true;
        BroadcastMessage("Pause");

        gameManager.GetComponent<GameManagerScript>().LevelComplete(LevelNo);
    }

    public void Pause() {
        if (paused) return;
        paused = true;
    }
    public void Resume() {
        if (!paused) return;
        paused = false;
    }

    
}
