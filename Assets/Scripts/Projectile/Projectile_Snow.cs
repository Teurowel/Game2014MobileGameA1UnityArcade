//SourceFileName : Projectile_Snow.cs
//Author's name : Doosung Jang
//Studnet Number : 101175013
//Date last Modified : Oct.19, 2020
//Program description : Projectile's base class
//Revision History : Oct.19, 2020 : Created, Added SpecialEffect

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Projectile_Snow : Projectile
{
    [SerializeField] float snowEffectDuration = 5f; //5 seconds of snow effect
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public override void SpecialEffect(Enemy target)
    {
        //Debug.Log("Snow special effect");
        //Make target affacted by snow
        target.HitBySnow(snowEffectDuration);

    }
}
