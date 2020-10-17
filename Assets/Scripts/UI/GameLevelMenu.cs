//SourceFileName : GameLevelMenu.cs
//Author's name : Doosung Jang
//Studnet Number : 101175013
//Date last Modified : Sep.18, 2020
//Program description : fuctions of game level menu such as going to gameover or game win
//Revision History : Sep.18, 2020 Adding GoToGameOverScene and GoToGameWinScene function

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLevelMenu : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    public void GoToGameOverScene()
    {
        SceneManager.LoadScene("GameOverScreen");
    }

    public void GoToGameWinScene()
    {
        SceneManager.LoadScene("GameWinScreen");
    }
}
