//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 1f; //Projectile speed
    int damage = 10; //Projectile damage, it comes from tower
    Tower owner = null; //Owner of this projectile

    Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        //Just move  to right direction
        transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);

        //Debug.Log(screenBounds);
        if(transform.position.x >= screenBounds.x)
        {
            owner.ReturnProjectile(gameObject);
        }
    }



    //Projectile layer only collide with enemy layer
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy comp = collision.gameObject.GetComponent<Enemy>();
        if(comp != null)
        {
            //Deal enemy
            comp.GetAttacked(damage);

            //Go back to projectile pool
            owner.ReturnProjectile(gameObject);
        }
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
