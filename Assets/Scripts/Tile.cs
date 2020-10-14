//SourceFileName : Tile.cs
//Author's name : Doosung Jang
//Studnet Number : 101175013
//Date last Modified : Sep.18, 2020
//Program description : fuctions of tile
//Revision History : Sep.18, 2020 Adding OnMouseDOwn funtion

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    Tower towerOnTile = null; //Tower that is currently placed on this tile
    public float towerYOffset = 3f; //When place tower, set offset to adjust position

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    private void OnMouseDown()
    {
        //Cost check
        //When player select tile, place tower
        if (TowerListPanel.instance.selectedTowerSlot != null && towerOnTile == null)
        {
            if (Player.instance.GetSunScore() >= TowerListPanel.instance.selectedTowerSlot.towerData.towerCost)
            {
                //Decrease sun score
                Player.instance.ChangeSunScore(-TowerListPanel.instance.selectedTowerSlot.towerData.towerCost);

                Vector3 towerPos = transform.position;
                towerPos.y += towerYOffset;

                GameObject tower = Instantiate(TowerListPanel.instance.selectedTowerSlot.towerData.towerPrefab, towerPos, Quaternion.identity);
                towerOnTile = tower.GetComponent<Tower>();

                //Deslect tower slot
                TowerListPanel.instance.DeselectTowerSlot();
            }
            //Debug.Log(transform.name);
        }
    }
}
