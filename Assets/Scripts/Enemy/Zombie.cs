//SourceFileName : Zombie.cs
//Author's name : Doosung Jang
//Studnet Number : 101175013
//Date last Modified : Oct.18, 2020
//Program description : Basic enemy zombie
//Revision History : Sep.18, 2020 Created
//                   Oct.18, 2020 Added play sound

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
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
