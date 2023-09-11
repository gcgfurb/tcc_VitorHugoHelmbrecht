using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnActivation : MonoBehaviour
{
    public GameObject livingThingThatWillDie;

    void OnEnable() {
        if (livingThingThatWillDie != null) {
            if (livingThingThatWillDie.TryGetComponent<Animator>(out var animator)) {
                animator.SetBool("isDead", true);
            }
        }
    }
}
