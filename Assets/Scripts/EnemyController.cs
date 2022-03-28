using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private int health = 100;
    private float time = 15;
    //private int damage = 0;
    private NavMeshAgent zombieNavMeshAgent;

    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Animator zombieAnimator;


    // Start is called before the first frame update
    void Start()
    {
        zombieNavMeshAgent = GetComponent<NavMeshAgent>();
        zombieAnimator = GetComponent<Animator>();
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else
        {
            playerTransform = transform;
        }
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health < 0)
        {
            Debug.Log("Zombie Health" + health);
            Destroy(gameObject);
        }
        else
        {
            ZombieDestination();
        }

        IncreaseHealth();

        //ZombieAttack();

        Debug.Log(health);
    }


    void ZombieAttack()
    {
        if(zombieNavMeshAgent.stoppingDistance == 3)
        {
            zombieAnimator.SetBool("Attack", true);
        }
        else
        {
            zombieAnimator.SetBool("Attack", false);
        }
    }
    void ZombieDestination()
    {
        if (gameManager.GetPlayerDead())
        {
            zombieNavMeshAgent.SetDestination(transform.position);
        }
        else
        {
            zombieNavMeshAgent.SetDestination(playerTransform.position);
        }
    }
    void IncreaseHealth()
    {
        if(Time.time > time )
        {
            time += Time.time;
            health += 20;
        }
    }

    public void GetDamage(int damage)
    {
        health -= damage;
    }

}
