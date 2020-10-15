using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Stats")]
    protected Stats stats = null; //Tower's stats

    [Header("Projectile")]
    [SerializeField] protected GameObject projectilePrefab = null; //Projectile prefab
    protected Queue<GameObject> projectilePool = null; //Projectile pool
    [SerializeField] protected int maxNumOfProjectile = 10; //Number of projectile pool
    [SerializeField] protected LayerMask enemyLayer; //Which layer tower atatck
    [SerializeField] protected float rayCastYOffset = 0.5f; //Y offset for ray cast start pos
    [SerializeField] protected float projectileSpawnXOffset = 3f; //X Offset where projectile spawn


    protected bool hasAttacked = false; //Did tower attack?
    // Start is called before the first frame update
    protected virtual void Start()
    {
        //Set hp as max hp
        stats = GetComponent<Stats>();
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

    //Get projectile and put it in queue
    public void ReturnProjectile(GameObject projectile)
    {
        projectile.SetActive(false);
        projectilePool.Enqueue(projectile);
    }
}
