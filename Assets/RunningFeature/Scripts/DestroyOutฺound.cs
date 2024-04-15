using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutฺound : MonoBehaviour
{
    public float lowerBound = -5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        destroyObject();
    }

    void destroyObject()
    {
        if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
        }
    }
}
