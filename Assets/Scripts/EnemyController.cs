using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private int health = 100;
    //private int damage = 0;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health < 0)
        {
            Debug.Log("Zombie Health" + health);
            Destroy(gameObject);
        }
        Debug.Log(health);
    }

    public void GetDamage(int damage)
    {
        health -= damage;
    }

}
