using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject projectilePrefab;  // Prefab of the circle projectile
    public float spawnInterval = 1f;     // Time interval between spawning projectiles
    public float spawnForce = 5f;        // Force to apply to the spawned projectiles

    private float screenHalfWidth;       // Half width of the screen
    private float screenHalfHeight;      // Half height of the screen

    private void Start()
    {
        // Calculate screen boundaries based on the camera's orthographic size
        float cameraOrthographicSize = Camera.main.orthographicSize;
        float cameraAspectRatio = Camera.main.aspect;
        screenHalfWidth = cameraOrthographicSize * cameraAspectRatio;
        screenHalfHeight = cameraOrthographicSize;

        // Start spawning projectiles
        InvokeRepeating("SpawnProjectile", 0f, spawnInterval);
    }

    private void SpawnProjectile()
    {
        // Generate a random position outside the screen
        Vector3 spawnPosition = Vector3.zero;
        int side = Random.Range(0, 4); // Randomly choose a side (0: top, 1: right, 2: bottom, 3: left)

        switch (side)
        {
            case 0: // Top
                spawnPosition = new Vector3(Random.Range(-screenHalfWidth, screenHalfWidth), screenHalfHeight + 1f, 0f);
                break;
            case 1: // Right
                spawnPosition = new Vector3(screenHalfWidth + 1f, Random.Range(-screenHalfHeight, screenHalfHeight), 0f);
                break;
            case 2: // Bottom
                spawnPosition = new Vector3(Random.Range(-screenHalfWidth, screenHalfWidth), -screenHalfHeight - 1f, 0f);
                break;
            case 3: // Left
                spawnPosition = new Vector3(-screenHalfWidth - 1f, Random.Range(-screenHalfHeight, screenHalfHeight), 0f);
                break;
        }

        // Instantiate the projectile prefab and apply force
        GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        Vector2 spawnForceDirection = Random.insideUnitCircle.normalized;
        rb.AddForce(spawnForceDirection * spawnForce, ForceMode2D.Impulse);
    }
}