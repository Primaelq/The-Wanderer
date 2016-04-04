﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpellTemplate : MonoBehaviour
{
    public float chargingTime = 2.0f;
    public int damages = 10;

    public Color loadedColor;

    [HideInInspector]
    public float startLoadTime;

    private float currentTime;
    
	void Start ()
    {
        currentTime = chargingTime;
        startLoadTime = -chargingTime;
    }
	
	void Update ()
    {
        currentTime = Time.time - startLoadTime;

        if (currentTime >= chargingTime)
        {
            transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().color = loadedColor;
        }
        else
        {
            transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().color = Color.white;

            transform.GetChild(0).GetComponent<Slider>().value = currentTime / chargingTime;
        }
    }
}