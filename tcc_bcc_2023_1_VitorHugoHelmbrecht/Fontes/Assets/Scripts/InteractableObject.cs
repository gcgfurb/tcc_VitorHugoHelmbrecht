using Assets.Scripts;
using Assets.Scripts.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableObject : MonoBehaviour
{
    public EItems itemType;
    public float rotationSpeed = 8;

    private InputData inputData;
    private bool startedInteraction = false;
    private bool isTheItem = false;

    private Vector3 initialPosition = Vector3.zero;
    private Rigidbody rigidBody;

    void Start() {
        inputData = GetComponentInParent<InputData>();
        rigidBody = GetComponent<Rigidbody>();

        isTheItem = Utils.CurrentItem == itemType;
        gameObject.SetActive(isTheItem);
    }

    void Update() {
        if (!isTheItem) return;

        if (!startedInteraction) {
            transform.Rotate(
                rotationSpeed * Time.deltaTime * Vector3.right +
                rotationSpeed * Time.deltaTime * Vector3.up +
                rotationSpeed * Time.deltaTime * Vector3.forward,
                Space.Self
            );
        }

        RotateItem();

        CheckIfTheAngleIsRight();
    }

    private void RotateItem() {
        if (!inputData._rightController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out bool isTriggered)) return;
        if (!inputData._rightController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.devicePosition, out Vector3 controllerPosition)) return;
        if (!inputData._rightController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceRotation, out Quaternion controllerRotation)) return;

        if (!isTriggered) {
            initialPosition = controllerPosition;
            return;
        } else Debug.Log(transform.eulerAngles);

        var position = initialPosition - controllerPosition;

        if (position == Vector3.zero) {
            rigidBody.angularVelocity = Vector3.zero;
        }

        if (!startedInteraction)
            startedInteraction = true;

        transform.rotation = controllerRotation;
        return;
    }

    private void CheckIfTheAngleIsRight() {
        if (transform.eulerAngles.IsInRange(Utils.FinalAngle, 5)) {
            SceneManager.LoadScene(Utils.NextScene, LoadSceneMode.Single);
        }
    }
}
