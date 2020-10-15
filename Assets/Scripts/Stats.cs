using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Common stats for tower and enemy

[System.Serializable]
public class Stats : MonoBehaviour
{
    [Header("Stats")]
    public int hp = 100; //Health Point for tower
    public int maxHp = 100; //Max health point for tower;
    public int damage = 10; //Attack damage
    public float attackRange = 10f; //Attack range
    public float attackPerSec = 1; //attack every seconds



    public event System.Action<int, int> OnHealthChanged; //HealthUI subscribe
    public event System.Action OnHealthBelowZero; //Enemy subscribe

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HealthChange(int modifier)
    {
        hp += modifier;

        //Trigger event
        if (OnHealthChanged != null)
        {
            OnHealthChanged(hp, maxHp);
        }

        //Trigger event
        if (hp <= 0)
        {
            if (OnHealthBelowZero != null)
            {
                OnHealthBelowZero();
            }
        }
    }
}
