using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceText  : MonoBehaviour {

    public float distanceMultiplier;
    public float distanceBoost;

    private float Distance;
    private float startTime;
    private float playTime;
    private float timeInterval;
    private TextMeshProUGUI distanceDisplay;


	// Use this for initialization
	void Start ()
    {
		playTime = 0;
        startTime = Time.time;
        distanceDisplay = GetComponent<TextMeshProUGUI>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (PlayerController.instance.canMove)
        {
            playTime += (Time.deltaTime * GameManager.instance.multiplier);

            //if (playTime - timeInterval > 30.0f)
            //{
            //    distanceMultiplier += (distanceBoost * GameManager.instance.multiplier);
            //    timeInterval += 30.0f;
            //}

            //Distance = playTime * distanceMultiplier;

            distanceDisplay.text = "Distance Travelled: " + playTime.ToString("F2") + "m";
        }
    }
}
