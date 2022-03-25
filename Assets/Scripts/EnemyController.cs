using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private int health = 100;
    //private int damage = 0;
    private NavMeshAgent zombieNavMeshAgent;

    [SerializeField] private Transform playerTransform;


    // Start is called before the first frame update
    void Awake()
    {
        zombieNavMeshAgent = GetComponent<NavMeshAgent>();
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

        if(gameObject != null)
            zombieNavMeshAgent.destination = playerTransform.position;

    }

    public void GetDamage(int damage)
    {
        health -= damage;
    }

}
