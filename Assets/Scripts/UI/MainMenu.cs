﻿//SourceFileName : MainMenu.cs
//Author's name : Doosung Jang
//Studnet Number : 101175013
//Date last Modified : Sep.16, 2020
//Program description : fuctions of main menu such as play game or quit game
//Revision History : Sep.16, 2020 Adding PlayGame and QuitGame function




using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    public void PlayGame()
    {
        SceneManager.LoadScene("GameLevel01");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
