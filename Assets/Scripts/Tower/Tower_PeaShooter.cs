using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_PeaShooter : Tower
{
    Animator animator = null; //character's animator    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        projectilePool = new Queue<GameObject>();
        //Create projectile pool
        for (int i = 0; i < maxNumOfProjectile; ++i)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectile.SetActive(false);

            projectilePool.Enqueue(projectile);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Detect enemy
        if(DetectEnemy())
        {
            //Debug.Log("PeaShooter : Detect enemy");
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
        Debug.DrawLine(start, start + (transform.right * attackRange));

        //Cast ray cast
        RaycastHit2D result = Physics2D.Raycast(start, transform.right, attackRange, enemyLayer);
        if(result.collider != null)
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
            Invoke(nameof(ResetHasAttacked), 1f / attackPerSec);
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
            }
        }
    }

    void ResetHasAttacked()
    {
        hasAttacked = false;
    }
}
