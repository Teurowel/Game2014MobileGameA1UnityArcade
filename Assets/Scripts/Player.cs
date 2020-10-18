//SourceFileName : Player.cs
//Author's name : Doosung Jang
//Studnet Number : 101175013
//Date last Modified : Oct.16, 2020
//Program description : Player class which have information related to player status such as sun score
//Revision History : Oct.16, 2020 : Added sun score variable
//                                  Added OnSunScoreChange delgate to notify sun score text

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Singleton
    public static Player instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one of Player");
            return;
        }

        instance = this;
    }
    #endregion

    //Camera cam = null;
    //[SerializeField] LayerMask rayCastMask; //Which layer do we raycast?

    public Vector2 screenBounds; //Screen bounds

    [SerializeField] int sunScore = 100; //This will be used to place tower

    public delegate void OnSunScoreChange(int _sunScore); //delegate for sun score change
    public OnSunScoreChange onSunScoreChange; //Sun score text subscribe 

    // Start is called before the first frame update
    void Start()
    {
        //Calculate screen bounds
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        //Update global data
        GlobalData.Instance.sunScore = sunScore;
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public void ChangeSunScore(int value)
    {
        sunScore += value;

        GlobalData.Instance.sunScore = sunScore;

        onSunScoreChange.Invoke(sunScore);
    }

    public int GetSunScore()
    {
        return sunScore;
    }
}
