//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 1f; //Projectile speed
    Tower owner = null; //Owner of this projectile

    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        //Just move  to right direction
        transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
    }

    public void SetOwner(Tower _owner)
    {
        owner = _owner;
    }
}
