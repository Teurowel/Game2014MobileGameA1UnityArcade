using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Stats")]
    int hp = 100; //Health Point for tower
    [SerializeField] protected int maxHp = 100; //Max health point for tower;
    [SerializeField] protected int damage = 10; //Attack damage
    [SerializeField] protected float attackPerSec = 1; //attack every seconds
    [SerializeField] protected int maxNumOfProjectile = 10; //Number of projectile pool
    [SerializeField] protected float attackRange = 10f; //Attack range
    
    protected bool hasAttacked = false; //Did tower attack?

    [Header("Projectile")]
    [SerializeField] protected GameObject projectilePrefab = null; //Projectile prefab
    protected Queue<GameObject> projectilePool = null; //Projectile pool
    [SerializeField] protected LayerMask enemyLayer; //Which layer tower atatck
    [SerializeField] protected float rayCastYOffset = 0.5f; //Y offset for ray cast start pos
    [SerializeField] protected float projectileSpawnXOffset = 3f; //X Offset where projectile spawn


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
