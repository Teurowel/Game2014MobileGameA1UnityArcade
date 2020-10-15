//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    protected Stats stats; //enemy stats
    [SerializeField] protected float moveSpeed = 3; //move speed for enemy


    // Start is called before the first frame update
    protected virtual void Start()
    {
        stats = GetComponent<Stats>();

        if (stats != null)
        {
            stats.OnHealthBelowZero += OnHealthBelowZeroCallBack;
        }
    }

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
        stats.HealthChange(-towerDamage);
    }

    void OnHealthBelowZeroCallBack()
    {

        Destroy(gameObject);
    }
}
