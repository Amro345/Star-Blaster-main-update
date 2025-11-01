using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private float spawnRangeX = 12f;
    private float spawnPosZ = 5f;
    private float startDelay = 2f;
    private float spawnInterval = 0.9f;
    private bool isSpawning = true;
    private int maxEnemies = 5;

    private List<GameObject> spawnedEnemies = new List<GameObject>();

    void Start()
    {
        InvokeRepeating(nameof(SpawnRandomEnemy), startDelay, spawnInterval);
    }

    void SpawnRandomEnemy()
    {
        if (!isSpawning) return;

        spawnedEnemies.RemoveAll(enemy => enemy == null);
        if (spawnedEnemies.Count >= maxEnemies)
            return;

        Vector3 spawnPos;
        bool validPos = false;
        int safetyCounter = 0;

        do
        {
            spawnPos = new Vector3(Random.Range(2f, spawnRangeX), 7f, spawnPosZ);

            // check for overlap (no other collider in that area)
            Collider[] hitColliders = Physics.OverlapSphere(spawnPos, 1.5f); // radius controls how close they can be
            if (hitColliders.Length == 0)
            {
                validPos = true;
            }

            safetyCounter++;
            if (safetyCounter > 30) break;

        } while (!validPos);

        if (validPos)
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            GameObject newEnemy = Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
            spawnedEnemies.Add(newEnemy);
        }
    }

    public void StopSpawning()
    {
        isSpawning = false;
        CancelInvoke(nameof(SpawnRandomEnemy));
    }
}
