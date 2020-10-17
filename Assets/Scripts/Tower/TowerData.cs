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
