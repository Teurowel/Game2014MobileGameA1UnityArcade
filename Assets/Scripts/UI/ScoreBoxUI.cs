//SourceFileName : ScoreBoxUI.cs
//Author's name : Doosung Jang
//Studnet Number : 101175013
//Date last Modified : Oct.18, 2020
//Program description : ScoreBoxUI will get score from GlobalData and set the text
//Revision History : Oct.18, 2020 : Created


//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoxUI : MonoBehaviour
{
    TextMeshProUGUI scoreText = null; //text mesh pro for sun score text

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponentInChildren<TextMeshProUGUI>();
        
        if(scoreText != null && GlobalData.Instance != null)
        {
            scoreText.text = "Score: " + GlobalData.Instance.sunScore.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
