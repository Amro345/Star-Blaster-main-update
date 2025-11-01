using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Adjust this to change the speed of movement
    public GameObject bulletPrefab;
    public AudioClip bulletSoundClip; // Assign your sound clip here
    public GameObject nextLevelButton; // Reference to the Next Level button GameObject
    public TextMeshProUGUI gameOverText; // Reference to the Text Mesh Pro component for the "Game Over" message

    private AudioSource audioSource;
    private int enemyCount = 0; // Track the number of enemies hit
    private bool gameOver = false;

    void Start()
    {
        // Ensure there's an AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Deactivate the Next Level button and "Game Over" text initially
        nextLevelButton.SetActive(false);
        gameOverText.gameObject.SetActive(false);
    }

    void Update()
    {
        // Check if the player is destroyed
        if (gameOver)
        {
            return;
        }

        // Get the input from arrow keys
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * speed * Time.deltaTime;

        // Move the player
        transform.Translate(movement);

        // Restrict player's movement within range
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, 2f, 12.5f);
        transform.position = clampedPosition;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
            if (bulletSoundClip != null && audioSource != null)
            {
                audioSource.PlayOneShot(bulletSoundClip);
            }
        }
    }

    // Function to increment enemy count
    public void IncrementEnemyCount()
    {
        if (!gameOver)
        {
            enemyCount++;
            Debug.Log("Enemy Count: " + enemyCount);

            // Check if the player has hit 10 enemies
            if (enemyCount >= 40)
            {
                StopEnemySpawning();
                ShowNextLevelButton();
                ShowGameOverText();
                gameOver = true;
            }
        }
    }

    void StopEnemySpawning()
    {
        // Find all SpawnManager instances and stop spawning enemies
        SpawnManager[] spawnManagers = FindObjectsOfType<SpawnManager>();
        foreach (SpawnManager spawnManager in spawnManagers)
        {
            spawnManager.StopSpawning();
        }
    }

    void ShowNextLevelButton()
    {
        // Activate the Next Level button
        nextLevelButton.SetActive(true);
    }

    void ShowGameOverText()
    {
        // Activate the "Game Over" text
        gameOverText.gameObject.SetActive(true);
    }

    // Method to be called when the player is destroyed
   
}