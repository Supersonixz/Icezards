using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerr : MonoBehaviour
{
    private float horizontalInput;
    private float speed = 5;
    private float xRange = 2;

    // Update is called once per frame
    void Update()
    {
        //Assign A D input for character movement. 
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        //Check boundary that character can walk
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, 
            transform.position.y, transform.position.z);
        }
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, 
            transform.position.y, transform.position.z);
        }

    }
}
