﻿//SourceFileName : Enemy.cs
//Author's name : Doosung Jang
//Studnet Number : 101175013
//Date last Modified : Oct.18, 2020
//Program description : Base class for all enemy. It has common variable or function for all enemies
//Revision History : Oct.16, 2020 : Added stats, moveSpeed
//                                  Added detect enemy, hasAttacked, Attack()
//                   Oct.18, 2020 : Added play sound

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    protected Stats stats; //enemy stats
    [SerializeField] protected float moveSpeed = 3; //move speed for enemy
    [SerializeField] protected float rayCastXOffset = 0.5f; //Y offset for ray cast start pos
    [SerializeField] protected float rayCastYOffset = 0.5f; //Y Offset  for ray cast start pos

    [SerializeField] protected LayerMask towerLayer; //Which layer Enemy atatck

    bool hasStartedAttack = false; //Has enemy started attack?
    bool hasAttacked = false; //Has enemy attacked tower?

    Animator animator = null; //character's animator    


    float originMoveSpeed = 0f; //Save original move speed
    bool HasHitBySnow = false; //Has enemy hit by snow?
    float snowEffectTime = 0f; //Timer for snow effect duration

    // Start is called before the first frame update
    protected virtual void Start()
    {
        stats = GetComponent<Stats>();
        animator = GetComponentInChildren<Animator>();

        if (stats != null)
        {
            stats.OnHealthBelowZero += OnHealthBelowZeroCallBack;
        }

        originMoveSpeed = moveSpeed;
        Debug.Log(originMoveSpeed);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //Keep detecting tower
        Collider2D target = null;

        if((target = DetectTower()) != null)
        {
            //Debug.Log("Detect tower");
            //If enemy detected tower, attack

            //Check has started attack
            if(hasStartedAttack == false)
            {
                hasStartedAttack = true;
                //Change animatino using trigger
                animator.SetTrigger("attackTrigger");
            }

            Attack(target);
        }
        //If enemy doesn't detect tower, move
        else
        {
            //Stop attacking animatino
            if (hasStartedAttack == true)
            {
                hasStartedAttack = false;
                animator.SetTrigger("killedTower");
            }

            Move();
        }

        //Check snow effect duration
        SnowEffectDurationCheck();
    }

    protected virtual void Move()
    {
        transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0f, 0f);
    }

    //Attacked by tower
    public void GetAttacked(int towerDamage)
    {
        //Debug.Log("Enemy get damage: " + towerDamage);
        stats.HealthChange(-towerDamage);
    }

    void OnHealthBelowZeroCallBack()
    {

        Destroy(gameObject);
    }


    //Detect tower
    Collider2D DetectTower()
    {
        Vector3 start = transform.position;
        start.x += rayCastXOffset;
        start.y += rayCastYOffset;

        //Raycast Debug line
        Debug.DrawLine(start, start + (-transform.right * stats.attackRange));

        //Cast ray cast
        RaycastHit2D result = Physics2D.Raycast(start, -transform.right, stats.attackRange, towerLayer);
        if (result.collider != null)
        {
            return result.collider;
            
        }

        return null;
    }

    void Attack(Collider2D target)
    {
        if (hasAttacked == false)
        {
            //Debug.Log("Zombie : Attack");
            hasAttacked = true;

            
            //Damage tower
            Tower comp = target.gameObject.GetComponent<Tower>();
            if (comp != null)
            {
                //Deal enemy
                comp.GetAttacked(stats.damage);
            }


            //Play sound
            if (SoundManager.instance != null)
            {
                SoundManager.instance.Play("Zombie_AttackSFX");
            }
            


            //attack cool time
            Invoke(nameof(ResetHasAttacked), 1f / stats.attackPerSec);
        }
    }

    void ResetHasAttacked()
    {
        hasAttacked = false;
    }

    //When hit by snow projectile, decrease movement speed for a certain time
    public void HitBySnow(float snowEffectDuration)
    {
        if (HasHitBySnow == false)
        {
            //Decase movespeed to 1/2 of original move speed
            moveSpeed = originMoveSpeed * 0.5f;

            HasHitBySnow = true;
        }

        //If hit by snow again and agina, reassign snoweffectduration
        snowEffectTime = snowEffectDuration;
    }


    //Check snow effect duration
    void SnowEffectDurationCheck()
    {
        //If the enemy has hit by snow...
        if (HasHitBySnow)
        {
            //Decreaseing snow effec ttime
            snowEffectTime -= Time.deltaTime;

            //If snow effect time goes below zero..
            if(snowEffectTime <= 0)
            {
                //Reset move speed
                HasHitBySnow = false;
                moveSpeed = originMoveSpeed;
            }
        }
    }
}
