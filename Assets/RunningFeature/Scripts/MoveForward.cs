using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 10;
    public bool doResetMove;
    public float resetMoveEvery = 10;
    public float initialDelay;

    private float nextResetMoveTime;
    private Vector3 originalPos;
    private float timeToMove;

    private void Start()
    {
        originalPos = transform.position;
        timeToMove = Time.time + initialDelay;
        nextResetMoveTime = Time.time + resetMoveEvery + initialDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (doResetMove)
        {
            if(nextResetMoveTime <= Time.time) { 
                transform.position = originalPos;
                nextResetMoveTime = Time.time + resetMoveEvery;
            }
        }
        if(initialDelay == 0 || Time.time > timeToMove)
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
