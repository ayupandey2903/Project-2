using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    // public variables with tooltips
    [Header("Hunger settings of animal")]
    [Tooltip("Max hunger of the animal")] public int maxHunger = 3;
    [Tooltip("Current hunger of the animal")] public int currentHunger;

    // [Header("Hunger Slider")]
    // [Tooltip("Hunger Slider")] public FoodBar foodBar;
    FoodBar foodBar;

    private void Start()
    {
        foodBar = FindObjectOfType<FoodBar>();      // find the FoodBar script
        currentHunger = maxHunger;                  // set Current Hunger to Max hunger at start of the spawn
        foodBar.SetMaxHunger(maxHunger);            // set Slider maximum
    }

    void HitByProjectile(Collider other)
    { 
        Destroy(other.gameObject);                  // Destroy the projectile
        if (currentHunger > 1)                      // check if the current hunger is greater than 1
        {
            currentHunger--;                        // decrement the current hunger
            foodBar.SetHunger(currentHunger);       // set the hunger slider
        }
        else                                        // if current hunger is 1
        {
            Destroy(gameObject);                    // Destroy the animal
            GameManager.IncrementScore(maxHunger);           // Increment the score
        }
    }

    // When the animal collides with the something
    private void OnTriggerEnter(Collider other)
    {

        string tag = other.gameObject.tag;              // get tag of the other object
        
        if (tag == "Projectile")                        // check if the tag is "Projectile"
        {
            HitByProjectile(other);
        }
        else if (tag == "Player")                       // check if the tag is "Player"
        {
            Destroy(gameObject);                        // Destroy the animal
            
            GameManager.DecrementLives();               // decrement the lives
        }
        else if (tag == "Animal")                       // check if the tag is "Animal"
        {
            transform.Rotate(0, 180, 0);                // rotate the animal 180 degrees
        }
        else
        {
            Debug.Log("Something else collided with the animal");
        }
    }
}
