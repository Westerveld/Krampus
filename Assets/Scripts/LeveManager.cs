﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeveManager : MonoBehaviour {

    public string loadLevel;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(loadLevel);
        }
		
	}
}
