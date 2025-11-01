using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rocksspawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject restartButton;

    private float spawnRangeX = 12f;
    private float spawnPosZ = 5f;
    private float startDelay = 2f;
    private float spawnInterval = 0.9f;
    private bool isSpawning = true;

    void Start()
    {
        InvokeRepeating(nameof(SpawnRandomRock), startDelay, spawnInterval);
        if (restartButton != null)
            restartButton.SetActive(false);
    }

    void SpawnRandomRock()
    {
        if (!isSpawning) return;

        Vector3 spawnPos = new Vector3(Random.Range(2f, spawnRangeX), 6f, spawnPosZ);
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        GameObject rock = Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);

        RockCollision rockCollision = rock.AddComponent<RockCollision>();
        rockCollision.spawner = this;
    }

   // public void StopSpawning()
   // {
     //   isSpawning = false;
     //   CancelInvoke(nameof(SpawnRandomRock));
   // }

    public void ShowRestartButton()
    {
        if (restartButton != null)
            restartButton.SetActive(true);
    }

    private class RockCollision : MonoBehaviour
    {
        public rocksspawner spawner;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                //spawner.StopSpawning();
                spawner.ShowRestartButton();
                Time.timeScale = 0f;
            }
        }
    }
}
