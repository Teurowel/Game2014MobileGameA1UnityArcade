//SourceFileName : TowerListPanel.cs
//Author's name : Doosung Jang
//Studnet Number : 101175013
//Date last Modified : Oct.18, 2020
//Program description : TolwerListPanel UI class that control tower list panel
//Revision History : Sep.18, 2020 created, Added SetSelectedTowerSlot
//                   Oct.18, 2020 Added play sound


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
    public GameObject selectedSlotHighlight = null; //Image to highlight selected tower slot

    // Start is called before the first frame update
    void Start()
    {
        if(selectedSlotHighlight != null)
        {
            selectedSlotHighlight.SetActive(false);
        }
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public void SetSelectedTowerSlot(TowerSlot newSlot)
    {
        //If selectedTowerSlot is empty and is different from new slot, just set new slot
        if (selectedTowerSlot == null || selectedTowerSlot != newSlot)
        {
            selectedTowerSlot = newSlot;

            selectedSlotHighlight.SetActive(true);
            selectedSlotHighlight.transform.position = selectedTowerSlot.transform.position;
        }
        //If selected tower slot is the same as newSlot, unselect it
        else if (selectedTowerSlot == newSlot)
        {
            DeselectTowerSlot();
        }


        //Play sound
        if (SoundManager.instance != null)
        {
            SoundManager.instance.Play("TowerSelectSFX");
        }
    }

    public void DeselectTowerSlot()
    {
        selectedTowerSlot = null;
        selectedSlotHighlight.SetActive(false);
    }
}
