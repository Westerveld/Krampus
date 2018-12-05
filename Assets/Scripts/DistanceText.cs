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
        startTime = Time.time;
        distanceDisplay = GetComponent<TextMeshProUGUI>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        playTime = Time.time - startTime;
        if (playTime - timeInterval > 30.0f)
        {
            distanceMultiplier += distanceBoost;
            timeInterval += 30.0f;
        }

        Distance = playTime * distanceMultiplier;

        distanceDisplay.text = "Distance Travelled: " + Distance.ToString("F3") + "m";
    }
}
