using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAnimEvent : MonoBehaviour
{
    Projectile proj = null; //Projectile component in parent

    // Start is called before the first frame update
    void Start()
    {
        proj = GetComponentInParent<Projectile>();
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    //This will be an event that is called when collision animation is finished
    public void ProjectileColAnimFinishEvent()
    {
        //Debug.Log("OnProjectileCollide Event triggered");
        if (proj != null)
        {
            proj.OnProjectileColAnimFinished();
        }
    }
}
