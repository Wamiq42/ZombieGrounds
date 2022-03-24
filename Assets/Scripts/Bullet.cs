using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float speed = 10;
  

    
    //private Rigidbody bulletRigidBody;

    private void Awake()
    {
        //bulletRigidBody = GetComponent<Rigidbody>();
    }
    
   
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }
    


    
}
