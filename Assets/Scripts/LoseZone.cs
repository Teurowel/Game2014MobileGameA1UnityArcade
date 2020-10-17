//SourceFileName : LoseZone.cs
//Author's name : Doosung Jang
//Studnet Number : 101175013
//Date last Modified : Oct.17, 2020
//Program description : LoseZone is place where if enemy goes, player lose
//Revision History : Oct.17, 2020 Created

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseZone : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    //Will only collide with enemy layer
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("GameOverScreen");
    }
}
