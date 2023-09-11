using System;
using UnityEngine;
using UnityEngine.AI;

public class NPCMain : MonoBehaviour
{
    public Transform[] goals;
    private NavMeshAgent agent;
    private int currentGoal = 0;

    public Transform holdingObject = null;
    public int turnHoldingObjectVisibleAfterWaypoint = 0;
    public int turnHoldingObjectHiddenAfterWaypoint = 0;
    public int droptObjectAtWaypoint = -1;
    public Camera initialCamera;

    private Animator animator;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.destination = goals[currentGoal].position;
    }

    private void Update() {
        if (currentGoal < goals.Length) {
            agent.destination = goals[currentGoal].position;

            animator.SetFloat("Speed_f", agent.speed);

            if (!agent.pathPending && agent.remainingDistance < agent.speed) {
                currentGoal++;
            }

            if (holdingObject != null) {
                CheckShowObject();
                CheckHideObject();
                CheckDropObject();
            }
        } else {
            animator.SetFloat("Speed_f", 0);
        }
    }

    private void CheckShowObject() {
        ChangeVisibilityOfObjectAndChildren(holdingObject, turnHoldingObjectVisibleAfterWaypoint, true);
    }

    private void CheckDropObject() {
        if (droptObjectAtWaypoint < 0) return;

        if (currentGoal >= droptObjectAtWaypoint && holdingObject != null) {
            holdingObject.parent = null;
            Rigidbody rigidBody = holdingObject.GetComponent<Rigidbody>();
            rigidBody.useGravity = true;
        }
    }

    private void CheckHideObject() {
        ChangeVisibilityOfObjectAndChildren(holdingObject, turnHoldingObjectHiddenAfterWaypoint, false);
    }

    private void ChangeVisibilityOfObjectAndChildren(Transform objectToHide, int waypoint, bool show) {
        if (waypoint < 0) return;

        if (currentGoal >= waypoint && objectToHide != null) {
            Debug.Log("entrou");
            ChangeVisibilityOfObject(objectToHide, show);

            if (objectToHide.childCount > 0) {
                for (int i = 0; i < objectToHide.childCount; i++) {
                    ChangeVisibilityOfObject(objectToHide.GetChild(i), show);
                }
            }
        }
    }

    private void ChangeVisibilityOfObject(Transform objectToHide, bool show) {
        if (objectToHide.TryGetComponent(out MeshRenderer holdingObjectRendered)) {
            Debug.Log("entrou de novo");
            holdingObjectRendered.enabled = show;
        }
    }
}
