//SourceFileName : PauseMenu.cs
//Author's name : Doosung Jang
//Studnet Number : 101175013
//Date last Modified : Oct.19, 2020
//Program description : PauseMenu will handle pause and resume
//Revision History : Oct.19, 2020 : Created, Added listOfUIToControl, PuaseGame, ResumeGame


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] List<GameObject> listOfUIToControl = new List<GameObject>(); //List of ui that has to be deactivated and activated

    // Start is called before the first frame update
    void Start()
    {
        //First diable pause menu
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    public void PauseGame()
    {
        //Show pause menu
        gameObject.SetActive(true);

        //Disable list of ui
        for(int i = 0; i < listOfUIToControl.Count; ++i)
        {
            listOfUIToControl[i].SetActive(false);
        }

        //stop world
        Time.timeScale = 0f;

        //Deselct tower
        TowerListPanel.instance.DeselectTowerSlot();
    }

    public void ResumeGame()
    {
        gameObject.SetActive(false);

        //Enable list of ui
        for (int i = 0; i < listOfUIToControl.Count; ++i)
        {
            listOfUIToControl[i].SetActive(true);
        }

        //play world
        Time.timeScale = 1f;
    }

    public void BackToMainMenu()
    {
        //play world
        Time.timeScale = 1f;

        SceneManager.LoadScene("MenuScreen");
    }
}
