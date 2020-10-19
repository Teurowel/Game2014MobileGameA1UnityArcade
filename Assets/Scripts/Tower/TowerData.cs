//SourceFileName : TowerData.cs
//Author's name : Doosung Jang
//Studnet Number : 101175013
//Date last Modified : Oct.16, 2020
//Program description : This is ScriptableObject that holds tower's data
//Revision History : Oct.16, 2020 : Created, Added tower's data


//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New TowerData", menuName = "Tower/TowerData")]
public class TowerData : ScriptableObject
{
    public string towerName = "New Tower";   //Tower name
    public Sprite towerIcon = null;  //Tower thumbnail Icon
    public int towerCost = 0; //Cost that is needed to build this tower

    public GameObject towerPrefab = null; //Tower prefab to instantitae

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
