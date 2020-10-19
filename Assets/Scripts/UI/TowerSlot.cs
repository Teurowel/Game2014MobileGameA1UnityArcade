//SourceFileName : TowerSlot.cs
//Author's name : Doosung Jang
//Studnet Number : 101175013
//Date last Modified : Sep.18, 2020
//Program description : TowerSlot represent one towe slot in slot panel
//Revision History : Sep.18, 2020 created, Added OnTowerSlotBtnClick

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSlot : MonoBehaviour
{
    public TowerData towerData = null; //Tower data
    [SerializeField] Image towerIcon = null;
    bool isSlotSelected = false; //Check if this slot is selected

    // Start is called before the first frame update
    void Start()
    {
        //Set towerIcon based on towerData
        if (towerData != null && towerIcon != null)
        {
            towerIcon.sprite = towerData.towerIcon;
        }
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public void OnTowerSlotBtnClick()
    {
        //Set selected tower slot
        TowerListPanel.instance.SetSelectedTowerSlot(this);
        //if (isSlotSelected == false)
        //{
        //    //Set selected tower data
        //    Player.instance.selectedTowerData = towerData;

        //    isSlotSelected = true;
        //}
    }
}
