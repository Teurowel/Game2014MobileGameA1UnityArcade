//SourceFileName : Life.cs
//Author's name : Doosung Jang
//Studnet Number : 101175013
//Date last Modified : Oct.17, 2020
//Program description : Life is player's final defense line. It will be activated when enemy comes close and swipe one line, after life is gone and enemy comes again, you lose
//Revision History : Oct.17, 2020 Created


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.5f; //move speed for enemy
    [SerializeField] float rayCastXOffset = 0.5f; //Y offset for ray cast start pos
    [SerializeField] float rayCastYOffset = 0.5f; //Y Offset  for ray cast start pos
    [SerializeField] float detectRange = 1f;
    [SerializeField] LayerMask enemyLayer; //Which layer Enemy atatck

    bool hasActivated = false; //Has life collided with enemy?



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Keep detecting enemy
        Collider2D target = null;
        if ((target = DetectEnemy()) != null)
        {
            //Activate life
            hasActivated = true;
        }

        //If life has activated...
        if (hasActivated == true)
        {
            MoveAndKillTarget(target);
        }

        CheckBound();
    }

    Collider2D DetectEnemy()
    {
        Vector3 start = transform.position;
        start.x += rayCastXOffset;
        start.y += rayCastYOffset;

        //Raycast Debug line
        Debug.DrawLine(start, start + (transform.right * detectRange));

        //Cast ray cast
        RaycastHit2D result = Physics2D.Raycast(start, transform.right, detectRange, enemyLayer);
        if (result.collider != null)
        {
            return result.collider;

        }

        return null;
    }

    void MoveAndKillTarget(Collider2D target)
    {
        //Move
        transform.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

        //Kill enemy
        if (target != null)
        {
            Enemy comp = target.gameObject.GetComponent<Enemy>();
            if (comp != null)
            {
                //Deal enemy, life kill instantly enemy
                comp.GetAttacked(9999);
            }
        }
    }

    void CheckBound()
    {
        //If it goes out of right edge of screen...
        if (transform.position.x >= Player.instance.screenBounds.x)
        {
            Destroy(gameObject);
        }
    }

}
