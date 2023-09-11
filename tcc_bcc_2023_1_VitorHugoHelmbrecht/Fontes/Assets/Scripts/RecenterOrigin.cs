using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;

public class RecenterOrigin : MonoBehaviour
{
    public InputActionProperty recenterButton;
    public Transform InitialPosition;

    void Update()
    {
        if (recenterButton.action.WasPressedThisFrame()) {
            Recenter();
        }
    }

    public void Recenter() {
        Debug.Log("AAAAAAA");

        XROrigin xrOrigin = GetComponent<XROrigin>();
        xrOrigin.MoveCameraToWorldLocation(InitialPosition.position);
        xrOrigin.MatchOriginUpCameraForward(InitialPosition.up, InitialPosition.forward);
    }
}
