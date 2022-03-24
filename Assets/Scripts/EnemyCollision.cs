using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    EnemyController enemyController;

    void Start()
    {
        enemyController = GetComponent<EnemyController>();
    }


    private void OnTriggerEnter(Collider other)
    {
        Bullet bulletScript = other.GetComponent<Bullet>();
        Debug.Log("triggered");
        if(bulletScript!=null)
        {
            Debug.Log("triggerd with Bullets");
            enemyController.GetDamage(bulletScript.damage);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Hand handScript = collision.gameObject.GetComponent<Hand>();
        Debug.Log("Collided");
        {
            Debug.Log("HandCollided");
            enemyController.GetDamage(20);
        }
    }



}
