using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LevelUIScript : MonoBehaviour
{
    public Text coverScreenText;
    public GameObject coverScreen;
    public GameObject resumeButton;
    public GameObject returnButton;
    public GameObject retryButton;

    public Button[] buttons;
    public string[] btnStrs;

    GameObject levelManager;

    bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        coverScreen.SetActive(false);
        resumeButton.SetActive(false);
        returnButton.SetActive(false);
        retryButton.SetActive(false);

        int btncount = Math.Min(btnStrs.Length, buttons.Length);
        for (int i = 0; i < btncount; i++) {
            string temp = btnStrs[i];
            buttons[i].onClick.AddListener(() => BtnClick(temp));
        }

        levelManager = GameObject.Find("LevelManager");
    }

    void BtnClick(string str) {
        if (str == "Return") {
            SceneManager.LoadSceneAsync("LevelSelectScene");
            return;
        }

        
        levelManager.GetComponent<LevelManagerScript>().BtnClick(str);
    }
    public void TimeEnd() {
        // for when timer runs out
        ShowCover("Time's Up!");
        returnButton.SetActive(true);
        retryButton.SetActive(true);
    }
    public void GameWin() {
        ShowCover("Congrats!");

        returnButton.SetActive(true);
        retryButton.SetActive(true);
    }

    public void Pause() {
        if (paused) return;
        paused = true;
        if (levelManager.GetComponent<LevelManagerScript>().noOfPieces != 0 && levelManager.GetComponent<TimerScript>().timer != 0.0f) resumeButton.SetActive(true);
        ShowCover("Game Paused");
    }
    public void Resume() {
        if (!paused) return;
        paused = false;
        resumeButton.SetActive(false);
        HideCover();
    }
    public void Retry() {
    	Scene scene = SceneManager.GetActiveScene();
    	SceneManager.LoadScene(scene.name);
    }

    void ShowCover(string DisplayText) {
        // Debug.Log("Show Cover");
        coverScreenText.text = DisplayText;
        coverScreen.SetActive(true);
    }
    void HideCover() {
        coverScreen.SetActive(false);
    }
}
