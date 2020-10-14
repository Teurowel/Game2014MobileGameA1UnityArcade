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
    }

    // Update is called once per frame
    void Update()
    {
       if(hasAttacked == false)
        {
            Debug.Log("PeaShooter : Attack");
            hasAttacked = true;

            animator.SetTrigger("attackTrigger");
            Invoke(nameof(ResetHasAttacked), 1f / attackPerSec);
        }
        //animator.SetTrigger
    }

    void ResetHasAttacked()
    {
        hasAttacked = false;
    }
}
