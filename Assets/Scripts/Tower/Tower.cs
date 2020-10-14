﻿//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Stats")]
    int hp = 100; //Health Point for tower
    [SerializeField] int maxHp = 100; //Max health point for tower;
    [SerializeField] int damage = 10; //Attack damage

    // Start is called before the first frame update
    void Start()
    {
        //Set hp as max hp
        hp = maxHp;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    //DoJob();
    //    Debug.Log("Tower Update");
    //}

    //Any tower will override this method
    protected virtual void DoJob()
    {
        Debug.Log("Tower base DoJob");
    }
}