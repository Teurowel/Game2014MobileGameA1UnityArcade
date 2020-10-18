//SourceFileName : Tower.cs
//Author's name : Doosung Jang
//Studnet Number : 101175013
//Date last Modified : Oct.17, 2020
//Program description : Base class for all tower. It has common variable or function for all tower
//Revision History : Oct.16, 2020 : Added stats, projectileprefab, projectilepool
//                   Oct.18, 2020 : Added sound                                 


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Stats")]
    protected Stats stats = null; //Tower's stats

    protected Animator animator = null; //character's animator

    // Start is called before the first frame update
    protected virtual void Start()
    {
        //Debug.Log("Tower Start");

        //Set hp as max hp
        stats = GetComponent<Stats>();
        animator = GetComponentInChildren<Animator>();

        if (stats != null)
        {
            stats.OnHealthBelowZero += OnHealthBelowZeroCallBack;
        }
    }

    //Update is called once per frame
    protected virtual void Update()
    {
        //DoJob();
        //Debug.Log("Tower Update");
    }

    public void GetAttacked(int enemyDamage)
    {
        //Debug.Log("Enemy get damage: " + towerDamage);
        if (stats != null)
        {
            stats.HealthChange(-enemyDamage);
        }
    }

    protected virtual void OnHealthBelowZeroCallBack()
    {
        //Play sound
        if (SoundManager.instance != null)
        {
            SoundManager.instance.Play("Zombie_KillTowerSFX");
        }

        Destroy(gameObject);
    }
}
