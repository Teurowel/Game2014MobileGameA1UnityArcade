//SourceFileName : Timer.cs
//Author's name : Doosung Jang
//Studnet Number : 101175013
//Date last Modified : Oct.17, 2020
//Program description : Timer UI
//Revision History : Oct.17, 2020 Created

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    TextMeshProUGUI timerText = null; //text mesh pro for sun score text

    [SerializeField] float startTime = 60f; //Start from 60seconds

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponentInChildren<TextMeshProUGUI>();
        timerText.text = startTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //Keep decreaseing time
        startTime -= Time.deltaTime;

        timerText.text = ((int)startTime).ToString();

        //If time is up you win
        if(startTime <= 0)
        {
            SceneManager.LoadScene("GameWinScreen");
        }
    }
}
