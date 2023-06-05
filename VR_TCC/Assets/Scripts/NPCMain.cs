using UnityEngine;
using UnityEngine.AI;

public class NPCMain : MonoBehaviour
{
    public Transform[] goals;
    private NavMeshAgent agent;
    private int currentGoal = 0;

    public Transform holdingObject = null;
    public int turnHoldingObjectVisibleAfterWaypoint = 0;
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

            CheckShowObject();
            CheckDropObject();
        } else {
            animator.SetFloat("Speed_f", 0);
        }
    }
    
    private void CheckShowObject() {
        if (currentGoal >= turnHoldingObjectVisibleAfterWaypoint) {
            if (holdingObject.TryGetComponent(out MeshRenderer holdingObjectRendered)) {
                holdingObjectRendered.enabled = true;
            }
        }
    }

    private void CheckDropObject() {
        if (currentGoal >= droptObjectAtWaypoint) {
            holdingObject.parent = null;
            Rigidbody rigidBody = holdingObject.GetComponent<Rigidbody>();
            rigidBody.useGravity = true;
        }
    }

}
 