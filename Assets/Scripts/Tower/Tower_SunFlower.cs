//SourceFileName : Tower_SunFlower.cs
//Author's name : Doosung Jang
//Studnet Number : 101175013
//Date last Modified : Oct.16, 2020
//Program description : SunFlower tower that generates sun periodically
//Revision History : Oct.16, 2020 Added sunPrefab, sunSpawnYOffset, minSpawnTime, maxSpawnTime

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Tower_SunFlower : PassiveTower
{
    [Header("Sun")]
    [SerializeField] GameObject sunPrefab = null; //Sun that SunFlower will spawn
    [SerializeField] float sunSpawnYOffset = 1f; //Y Offset for spawn position of sun


    [SerializeField] float minSpawnTime = 3f; //Minimun spawn time
    [SerializeField] float maxSpawnTime = 10f; //Maximum spawn time

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        //Keep invoking createsun
        Invoke("CreateSun", Random.Range(minSpawnTime, maxSpawnTime));
    }

    //Update is called once per frame
    protected override void Update()
    {
        base.Update();

        //DoJob();
    }

    //Sun is our score, will be used to create tower
    void CreateSun()
    {
        //Debug.Log("SunFlower: Create Sun");
        if(sunPrefab != null)
        {
            Vector3 sunPos = transform.position;
            sunPos.y += sunSpawnYOffset;

            //Create sun
            GameObject sun = Instantiate(sunPrefab, sunPos, Quaternion.identity);
            sun.GetComponent<Sun>().SetDestinationY(transform.position.y); //Set destination position where sun has to fall

            Invoke("CreateSun", Random.Range(minSpawnTime, maxSpawnTime));
        }
    }
}
