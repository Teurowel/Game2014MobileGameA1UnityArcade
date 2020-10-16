//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 1f; //Projectile speed
    int damage = 10; //Projectile damage, it comes from tower
    bool hasCollided = false; //Has projectile collided with enemy?

    Vector2 screenBounds; //Screen bounds

    Animator anim = null;
    Tower owner = null; //Owner of this projectile

    // Start is called before the first frame update
    void Start()
    {
        //Calculate screen bounds
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Just move  to right direction
        if (hasCollided == false)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);

            //Check screen bounds
            if (transform.position.x >= screenBounds.x)
            {
                owner.ReturnProjectile(gameObject);
            }
        }   
    }



    //Projectile layer only collide with enemy layer
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy comp = collision.gameObject.GetComponent<Enemy>();
        if(comp != null)
        {
            //Stop moving projectile
            hasCollided = true;

            //Deal enemy
            comp.GetAttacked(damage);

            //Trigger collide animation
            anim.SetTrigger("collisionTrigger");
        }
    }

    //This function will be called when projectile collision animation is finished
    public void OnProjectileColAnimFinished()
    {
        //Go back to projectile pool
        owner.ReturnProjectile(gameObject);
        hasCollided = false;
    }



    #region GetterSetter
    public void SetOwner(Tower _owner)
    {
        owner = _owner;
    }

    public void SetDamage(int _damage)
    {
        damage = _damage;
    }
    #endregion
}
