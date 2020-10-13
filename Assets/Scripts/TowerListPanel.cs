//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class TowerListPanel : MonoBehaviour
{
    #region Singleton
    public static TowerListPanel instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one of TowerListPanel");
            return;
        }

        instance = this;
    }
    #endregion

    public TowerSlot selectedTowerSlot = null; //Which tower is selected now


    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public void SetSelectedTowerSlot(TowerSlot newSlot)
    {
        //If selectedTowerSlot is empty, just set new slot
        if (selectedTowerSlot == null)
        {
            selectedTowerSlot = newSlot;
        }
        //If selected tower slot is the same as newSlot, unselect it
        else if (selectedTowerSlot == newSlot)
        {
            selectedTowerSlot = null;
        }
        //If selected tower slot is different with new slot, set new
        else
        {
            selectedTowerSlot = newSlot;
        }
    }
}
