//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    float destinationY = 0f; //Where to move
    [SerializeField] float fallSpeed = 1f; //How fast sun fall to ground
    [SerializeField] float lifeTime = 5f; //How long does sun live
    float createdTime = 0f; //When was this sun created
    [SerializeField] int sunValue = 50; //How much sun scroe does sun give

    //Start is called before the first frame update
    void Start()
    {
        createdTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //Keep moving to destinationY
        if(transform.position.y > destinationY)
        {
            
            transform.position -= new Vector3(0f, fallSpeed * Time.deltaTime, 0f);
        }

        //Check life time
        if(Time.time - createdTime >= lifeTime)
        {
            Destroy(gameObject);
        }
    }

    public void SetDestinationY(float y)
    {
        destinationY = y;
    }

    private void OnMouseDown()
    {
        //When player click sun, give sun value and destroy sun
        Player.instance.ChangeSunScore(sunValue);
        Destroy(gameObject);
    }
}
