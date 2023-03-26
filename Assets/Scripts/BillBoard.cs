using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    public new Transform camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;                              // get the main camera
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position + camera.forward);      // make the object look at the camera
    }
}
