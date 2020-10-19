﻿//SourceFileName : SunScoreText.cs
//Author's name : Doosung Jang
//Studnet Number : 101175013
//Date last Modified : Oct.18, 2020
//Program description : SunScoreText represent our sun scroe during game
//Revision History : Oct.18, 2020 : Created, Added OnSunScoreChangeCallback

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SunScoreText : MonoBehaviour
{
    TextMeshProUGUI sunScoreText = null; //text mesh pro for sun score text

    // Start is called before the first frame update
    void Start()
    {
        //Subscirbe to onSunScoreChange delegate
        Player.instance.onSunScoreChange += OnSunScoreChangeCallback;

        sunScoreText = GetComponent<TextMeshProUGUI>();
        if(sunScoreText != null)
        {
            sunScoreText.text = Player.instance.GetSunScore().ToString();
        }
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    void OnSunScoreChangeCallback(int _sunScore)
    {
        if(sunScoreText != null)
        {
            sunScoreText.text = _sunScore.ToString();
        }
    }
}
