using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_SunFlower : Tower
{
    [Header("Sun")]
    [SerializeField] GameObject sunPrefab = null; //Sun that SunFlower will spawn
    [SerializeField] float sunSpawnYOffset = 1f; //Y Offset for spawn position of sun
    [SerializeField] float sunSpawnCoolTime = 5f; //Spawn cool time

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        //Keep invoking createsun
        InvokeRepeating("CreateSun", sunSpawnCoolTime, sunSpawnCoolTime);
    }

    // Update is called once per frame
    //void Update()
    //{
    //    //base.Update();

    //    //DoJob();
    //}

    protected override void DoJob()
    {
        base.DoJob();
        Debug.Log("SunFlower DoJob");
    }

    //Sun is our score, will be used to create tower
    void CreateSun()
    {
        Debug.Log("SunFlower: Create Sun");
        if(sunPrefab != null)
        {
            Vector3 sunPos = transform.position;
            sunPos.y += sunSpawnYOffset;

            //Create sun
            GameObject sun = Instantiate(sunPrefab, sunPos, Quaternion.identity);
            sun.GetComponent<Sun>().SetDestinationY(transform.position.y); //Set destination position where sun has to fall
        }
    }
}
