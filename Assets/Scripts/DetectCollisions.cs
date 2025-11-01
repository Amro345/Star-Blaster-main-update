using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to an enemy
        
        
            // Destroy both the bullet and the enemy
            Destroy(gameObject); // Destroy the bullet
            Destroy(other.gameObject); // Destroy the enemy

            // Increment the enemy count in the PlayerController script
            PlayerController playerController = FindObjectOfType<PlayerController>();
            if (playerController != null)
            {
                playerController.IncrementEnemyCount();
            }
            else
            {
                Debug.LogError("PlayerController not found!");
            }
        }
    }

