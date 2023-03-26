using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // public variables with tooltips
    [Tooltip("Horizonatal Input")] public float horizontalInput;                             // horizontal input from player
    [Tooltip("In ms^-1")][SerializeField] public float speed = 20f;                          // speed of player
    [Tooltip("In m")][SerializeField] public float xRange = 10f;                             // horizontal range of player
    [Tooltip("In m")][SerializeField] public float zRange = 12f;                             // vertical range of player
    [Tooltip("Projectile Prefab")][SerializeField] public GameObject projectilePrefab;       // projectile prefab

    // private variables
    private float projectileYOffset = 1.5f;                                                  // Y axis offset of projectile from player
    private float projectileZOffset = 0.5f;
    private static bool gameActive = true;

    // function to move player
    void MovePlayer()
    {
        // Move the player left and right
        horizontalInput = Input.GetAxis("Horizontal");                                      // get horizontal input from player
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);      // move player horizontally
        // move the player forward and backward
        if (Input.GetKey(KeyCode.W))                                                        // if W is pressed, move forward
        {
            transform.Translate(speed * Time.deltaTime * Vector3.forward);
        }
        if (Input.GetKey(KeyCode.S))                                                        // if S is pressed, move backward
        {
            transform.Translate(speed * Time.deltaTime * Vector3.back);
        }
        // Keep the player in x bounds
        if (transform.position.x < -xRange)                                                 // if player is out of bounds, move back into bounds
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)                                                  // if player is out of bounds, move back into bounds
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        // keep the player in z bounds
        if (transform.position.z < -zRange)                                                 // if player is out of boundsm move back into bounds
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
        if (transform.position.z > zRange)                                                  // if player is out of bounds, move back into bounds
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
    }

    // set Game Active to false
    public static void SetGameOver()
    {
        gameActive = false;
    }

    // function to launch projectile
    void LaunchProjectile()
    {

        // if space is pressed, launch a projectile from the player
        if (Input.GetKeyDown(KeyCode.Space) && gameActive)
        {
            // instantiate projectile at player position with an offset in the y direction
            Instantiate(projectilePrefab, transform.position + new Vector3(0, projectileYOffset, projectileZOffset), projectilePrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        LaunchProjectile();
    }
}
