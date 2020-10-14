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

    [SerializeField] int sunScore = 100; //This will be used to place tower

    public delegate void OnSunScoreChange(int _sunScore); //delegate for sun score change
    public OnSunScoreChange onSunScoreChange; //Sun score text subscribe 

    // Start is called before the first frame update
    void Start()
    {
        //cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Left mouse button
        //if(Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit result;

        //    if (Physics.Raycast(ray, out result, 100.0f))
        //    {
        //        if(result.collider != null)
        //        {
        //            Debug.Log(result.collider.gameObject.name);
        //        }
        //    }
        //}
    }

    public void ChangeSunScore(int value)
    {
        sunScore += value;

        onSunScoreChange.Invoke(sunScore);
    }

    public int GetSunScore()
    {
        return sunScore;
    }
}
