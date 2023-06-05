using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float speed;
    public bool leaningInTheWall;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetBool("Leaning_b", leaningInTheWall);
        animator.SetFloat("Speed_f", speed);
    }
}
