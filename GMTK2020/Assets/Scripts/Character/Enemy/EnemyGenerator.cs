using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    private GameObject skeletonPrefab; 
    private GameObject zombiePrefab;
    private GameObject tinyguyPrefab;

    public Transform[] SpawnPositions = new Transform[2];

    public int maxDrops = 10;
    private int counter = 0;
    private int timeUntilDrop = 2;

    private int chanceToSpawnSkeleton = 20;
    private int chanceToSpawnZombie = 0;


    private void Start()
    {
        tinyguyPrefab = (GameObject)Resources.Load("Prefabs/TinyGuy");
        skeletonPrefab = (GameObject)Resources.Load("Prefabs/Skeleton");
        zombiePrefab = (GameObject)Resources.Load("Prefabs/Zombie");

        InvokeRepeating("EnemyWave", 2f, maxDrops * timeUntilDrop + 5);
    }

    void EnemyWave()
    {
        counter = 0;
        maxDrops++;
        if(chanceToSpawnZombie <= 80) chanceToSpawnZombie += 5;
        if(chanceToSpawnSkeleton <= 80) chanceToSpawnSkeleton += 5;
        InvokeRepeating("EnemyDrop", 1f, timeUntilDrop);
    }

    void EnemyDrop()
    {
        if(counter >= maxDrops) CancelInvoke("EnemyDrop");

        //chances to spawn enemies depends on their type
        if(Random.Range(0,100) <= chanceToSpawnZombie) Instantiate(zombiePrefab, SpawnPositions[Random.Range(0,2)].position, Quaternion.identity);
        else if(Random.Range(0,100) <= chanceToSpawnSkeleton) Instantiate(skeletonPrefab, SpawnPositions[Random.Range(0,2)].position, Quaternion.identity);
        else Instantiate(tinyguyPrefab, SpawnPositions[Random.Range(0,2)].position, Quaternion.identity);
        
        counter ++;
    }
}