using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private float timeOfLastAttack;

    private void Update()
    {
       
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("Controller Collider Hit");
        DamageHit damageHitScript = hit.collider.GetComponent<DamageHit>();
        if (damageHitScript != null)
        {
            Debug.Log("health lowered");
            if(Time.time > timeOfLastAttack)
            {
                timeOfLastAttack += 5.0f;
                gameObject.GetComponent<PlayerController>().GetPlayerManager().GetDamage(damageHitScript.damage);
            }
            
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    DamageHit damageHitScript = other.GetComponent<DamageHit>();
    //    if (damageHitScript != null)
    //    {

    //    }
    //}
}
