using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // public variables with tooltips
    // Game over canvas
    // [Tooltip("Game Over Canvas")][SerializeField] public GameObject gameOverCanvas;     // Game over canvas
    
    // private variables
    private float topbound = 90f;       // top bound
    private float lowerbound = -20f;    // lower bound
    private float rightbound = 20f;     // right bound
    private float leftbound = -20f;     // left bound

    // destroys the object if it goes out of bounds
    void DestroyObject()
    {
        if (transform.position.z > topbound)
        {
            Destroy(gameObject);    // Destroy the animal
        }
        else if (transform.position.z < lowerbound)
        {
            // gameOverCanvas.SetActive(true);     // Show the game over canvas
            Destroy(gameObject);                // Destroy the animal

            GameManager.DecrementLives();                // Decrement the lives
        }
        else if (transform.position.x > rightbound)
        {
            Destroy(gameObject);    // Destroy the animal
        }
        else if (transform.position.x < leftbound)
        {
            Destroy(gameObject);    // Destroy the animal
        }
    }

    // Update is called once per frame
    void Update()
    {
        DestroyObject();
    }
}
