//SourceFileName : EnemySpanwer.cs
//Author's name : Doosung Jang
//Studnet Number : 101175013
//Date last Modified : Oct.16, 2020
//Program description : EnemySpawner will spawn enemy periodically.
//Revision History : Oct.16, 2020 Added listOfEnemy, listOfSpawnPoint, minSpawnTime, maxSpawnTime, spawnPointXOffset, spawnPointYOffset

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> listOfEnemy = new List<GameObject>(); //List of spanwerable enemy
    [SerializeField] List<Transform> listOfSpawnPoint = new List<Transform>(); //List of spawn point

    [SerializeField] float firstSpawnTime = 10f; //After 10 seconds, start spawning
    [SerializeField] float minSpawnTime = 3f; //Minimun spawn time
    [SerializeField] float maxSpawnTime = 7; //Maximum spawn time

    [SerializeField] float spawnPointXOffset = 0.5f; //X offset from spawn point
    [SerializeField] float spawnPointYOffset = 0.5f; //Y offset from spawn point



    //Start is called before the first frame update
    void Start()
    {
        //Start invoking SpawnEnemy at random time
        if (listOfSpawnPoint.Count != 0 && listOfEnemy.Count != 0)
        {
            Invoke("SpawnEnemy", firstSpawnTime);
        }
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    void SpawnEnemy()
    {
        //Get random spawn point
        int spawnPointIdx = Random.Range(0, listOfSpawnPoint.Count);

        //Get random enemy
        int enemyIdx = Random.Range(0, listOfEnemy.Count);

        //Adjust spawn position
        Vector3 spawnPos = listOfSpawnPoint[spawnPointIdx].position;
        spawnPos.x += spawnPointXOffset;
        spawnPos.y += spawnPointYOffset;

        //Spawn enemy
        Instantiate(listOfEnemy[enemyIdx], spawnPos, Quaternion.identity);


        //Invoke spawn enemy again
        Invoke("SpawnEnemy", Random.Range(minSpawnTime, maxSpawnTime));
    }
}
