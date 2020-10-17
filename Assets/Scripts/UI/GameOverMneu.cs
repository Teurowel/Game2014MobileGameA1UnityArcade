//SourceFileName : GameOverMenu.cs
//Author's name : Doosung Jang
//Studnet Number : 101175013
//Date last Modified : Sep.18, 2020
//Program description : fuctions of game over menu such as going to mainmenu or playing again level
//Revision History : Sep.18, 2020 Adding PlayAgain and BackToMainMenu function

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMneu : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    public void PlayAgain()
    {
        SceneManager.LoadScene("GameLevel01");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MenuScreen");
    }
}
