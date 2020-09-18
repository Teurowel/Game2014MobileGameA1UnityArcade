//SourceFileName : GameWinMenu.cs
//Author's name : Doosung Jang
//Studnet Number : 101175013
//Date last Modified : Sep.18, 2020
//Program description : fuctions of game win menu such as going to mainmenu
//Revision History : Sep.18, 2020 Adding GoToMainMenu funtion

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinMenu : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MenuScreen");
    }
}
