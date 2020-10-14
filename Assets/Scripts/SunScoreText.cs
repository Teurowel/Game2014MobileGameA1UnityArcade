using System.Collections;
using System.Collections.Generic;
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
