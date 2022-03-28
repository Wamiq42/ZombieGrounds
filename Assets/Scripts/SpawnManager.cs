using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawnLocations;
    [SerializeField] private GameObject zombie;
    private int randomIndex;
    private float start = 2.0f;
    private float interval = 3f;
    //private bool isGameOver = true;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnZombies", start, interval);
    }

    void Update()
    {
       
    }

    void SpawnZombies()
    {
        randomIndex = Random.Range(0,spawnLocations.Length);
        Instantiate(zombie, spawnLocations[randomIndex].position, zombie.transform.rotation);
    }

    //IEnumerator ZombieSpawnDelay()
    //{
    //    yield return new WaitForSeconds(timer);
    //      SpawnZombies();
       
    //}
   
}
