//SourceFileName : RandomSunGenerator.cs
//Author's name : Doosung Jang
//Studnet Number : 101175013
//Date last Modified : Oct.18, 2020
//Program description : RandomSunGenerator will randomly generate sun from sky
//Revision History : Oct.18, 2020 : Created

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class RandomSunGenerator : MonoBehaviour
{
    [SerializeField] float spawnXOffset = 2f;
    [SerializeField] float spawnTopOffset = 2f;
    [SerializeField] float spawnBottomOffset = 2f;

    float spawnLeftBound = 0f;
    float spawnRightBound = 0f;
    float spawnTopBound = 0f;
    float spawnBottomBound = 0f;

    [SerializeField] float minSpawnTime = 5f;
    [SerializeField] float maxSpawnTime = 10f;
    [SerializeField] float firstSpawnTime = 10f;

    [SerializeField] GameObject sunPrefab = null;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        //Calculate spawn bound
        spawnLeftBound = -screenBounds.x + spawnXOffset;
        spawnRightBound = screenBounds.x - spawnXOffset;
        spawnTopBound = screenBounds.y - spawnTopOffset;
        spawnBottomBound = -screenBounds.y + spawnBottomOffset;


        Invoke("SpawnSun", firstSpawnTime);
    }

    //// Update is called once per frame
    //void Update()
    //{
    //}

    //Randomly spawn sun
    void SpawnSun()
    {
        if(sunPrefab != null)
        {
            Vector3 spawnPos = new Vector3(Random.Range(spawnLeftBound, spawnRightBound), transform.position.y, 0f);

            GameObject sun = Instantiate(sunPrefab, spawnPos, Quaternion.identity);
            sun.GetComponent<Sun>().SetDestinationY(Random.Range(spawnBottomBound, spawnTopBound)); //Set destination position where sun has to fall
        }

        Invoke("SpawnSun", Random.Range(minSpawnTime, maxSpawnTime));
    }
}
