using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public static CameraMover Instance;
    private Animator animator;
    private void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();
    }

    public void StartMove()
    {
        animator.Play("Start");
    }

}
