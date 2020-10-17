//SourceFileName : Active.cs
//Author's name : Doosung Jang
//Studnet Number : 101175013
//Date last Modified : Oct.17, 2020
//Program description : Activetower is the tower which shoot projectile
//Revision History : Oct.17, 2020 Created

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTower : Tower
{
    [Header("Projectile")]
    [SerializeField] protected GameObject projectilePrefab = null; //Projectile prefab
    protected Queue<GameObject> projectilePool = null; //Projectile pool
    protected List<GameObject> projectileRef = null; //Reference to all projectile(Tower should destroy all projectile when tower get destoryed)
    [SerializeField] protected int maxNumOfProjectile = 10; //Number of projectile pool
    [SerializeField] protected LayerMask enemyLayer; //Which layer tower atatck
    [SerializeField] protected float rayCastYOffset = 0.5f; //Y offset for ray cast start pos
    [SerializeField] protected float projectileSpawnXOffset = 3f; //X Offset where projectile spawn


    protected bool hasAttacked = false; //Did tower attack?

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        Debug.Log("ActiveTower Start");

        //Create projectile pool and ref
        projectilePool = new Queue<GameObject>();
        projectileRef = new List<GameObject>();
        for (int i = 0; i < maxNumOfProjectile; ++i)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectile.SetActive(false);

            projectilePool.Enqueue(projectile);
            projectileRef.Add(projectile);
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        //Detect enemy
        if (DetectEnemy())
        {
            //If it detected enemy, attack
            Attack();
        }
    }

    //Keep checking if enemy is in attack range
    bool DetectEnemy()
    {
        Vector3 start = transform.position;
        start.x += projectileSpawnXOffset;
        start.y += rayCastYOffset;

        //Raycast Debug line
        Debug.DrawLine(start, start + (transform.right * stats.attackRange));

        //Cast ray cast
        RaycastHit2D result = Physics2D.Raycast(start, transform.right, stats.attackRange, enemyLayer);
        if (result.collider != null)
        {
            return true;
        }

        return false;
    }

    //Attack
    void Attack()
    {
        if (hasAttacked == false)
        {
            //Debug.Log("PeaShooter : Attack");
            hasAttacked = true;

            //Shoot projectile
            ShootProjectile();




            //Change animatino using trigger
            animator.SetTrigger("attackTrigger");

            //attack cool time
            Invoke(nameof(ResetHasAttacked), 1f / stats.attackPerSec);
        }
    }

    void ShootProjectile()
    {
        //Shoot projectile
        if (projectilePool.Count != 0)
        {
            //Get projectile from pool
            GameObject projectile = projectilePool.Dequeue();

            //Activate projectile
            projectile.SetActive(true);

            //Set projectile pos
            Vector3 projectilePos = transform.position;
            projectilePos.x += projectileSpawnXOffset;
            projectilePos.y += rayCastYOffset;
            projectile.transform.position = projectilePos;

            //Set owner of projectile
            Projectile projComp = projectile.GetComponent<Projectile>();
            if (projComp != null)
            {
                projComp.SetOwner(this);
                projComp.SetDamage(stats.damage);
            }
        }
    }

    void ResetHasAttacked()
    {
        hasAttacked = false;
    }

    //Get projectile and put it in queue
    public void ReturnProjectile(GameObject projectile)
    {
        projectile.SetActive(false);
        projectilePool.Enqueue(projectile);
    }

    protected override void OnHealthBelowZeroCallBack()
    {
        //Destroy projectile pool
        if (projectilePool != null)
        {
            for (int i = 0; i < projectileRef.Count; ++i)
            {
                Destroy(projectileRef[i]);
            }

        }

        base.OnHealthBelowZeroCallBack();
    }
}
