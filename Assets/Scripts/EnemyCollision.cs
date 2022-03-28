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


    private void OnTriggerExit(Collider other)
    {
        Bullet bulletScript = other.GetComponent<Bullet>();
        Debug.Log("triggered");
        if (bulletScript != null)
        {
            Debug.Log("triggerd with Bullets");
            enemyController.GetDamage(bulletScript.damage);
            Destroy(other);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        DamageHit damageHitScript = collision.gameObject.GetComponent<DamageHit>();
        Debug.Log("Collided");
        if(damageHitScript != null)
        {
            Debug.Log("HandCollided");
            enemyController.GetDamage(damageHitScript.GetDamage());
        }
    }



}
