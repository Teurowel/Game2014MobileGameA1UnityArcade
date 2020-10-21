//SourceFileName : ConeheadZombie.cs
//Author's name : Doosung Jang
//Studnet Number : 101175013
//Date last Modified : Oct.19, 2020
//Program description : Conehead Zombie is stronger than normal zombie
//Revision History : Oct.19, 2020 Created,

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class ConeheadZombie : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        //Play sound
        if (SoundManager.instance != null)
        {
            SoundManager.instance.Play("ZombieSFX");
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        //Debug.Log("Zombie update");
        base.Update();
    }
}
