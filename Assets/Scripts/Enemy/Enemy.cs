//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] protected int hp = 100; //Health for enemy
    [SerializeField] protected int maxHp = 100; //Max health for enemy
    [SerializeField] protected int damage = 10; //damage for enemy
    [SerializeField] protected float moveSpeed = 3; //move speed for enemy


    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    protected virtual void Update()
    {
        //Debug.Log("Enemy update");
        //Basic movement
        Move();
    }

    protected virtual void Move()
    {
        transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0f, 0f);
    }

    //Attacked by tower
    public void GetAttacked(int towerDamage)
    {
        //Debug.Log("Enemy get damage: " + towerDamage);
        hp -= towerDamage;
    }
}
