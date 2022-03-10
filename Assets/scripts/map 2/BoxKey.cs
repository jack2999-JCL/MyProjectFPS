using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoxKey : MonoBehaviour
{

    public float health = 30;
    public GameObject SpawnKey;
    
    int number = 8;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }
    void Start()
    {
       
    }
    void Die()
    {
        Destroy(gameObject);

        int RandomKey = Random.Range(1, number);
        
        if (RandomKey != 1)
        {
            number -= 1;
            RandomKey = Random.Range(1, number);

        }
        // else
         if (RandomKey == 1)
        {
            Instantiate(SpawnKey, transform.position, transform.rotation);
            
            
        }


    }


}

