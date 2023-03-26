using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    // public variables with tooltips
    [Tooltip("In ms^-1")][SerializeField] public float speed = 40.0f;  // Speed in meters per second

    // Update is called once per frame
    void Update()
    {
        // Move the object forward
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }
}
