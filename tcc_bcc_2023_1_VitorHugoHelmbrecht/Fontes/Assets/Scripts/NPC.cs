using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float speed;
    public bool leaningInTheWall;

    private Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        if (animator != null) {
            animator.SetBool("Leaning_b", leaningInTheWall);
            animator.SetFloat("Speed_f", speed);
        } else {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }
}
