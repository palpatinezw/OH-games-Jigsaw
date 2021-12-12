using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MenuScript : MonoBehaviour
{
    public string[] toActive;
    public Button[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        setActive("HomeScreen");

        int btncount = Math.Min(toActive.Length, buttons.Length);
        for (int i = 0; i < btncount; i++) {
        	string temp = toActive[i];
        	buttons[i].onClick.AddListener(() => setActive(temp));
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
}
