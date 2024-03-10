using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(ActionBasedContinuousMoveProvider))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionReference sprintActionReference;
    private XROrigin xrRig;
    private CapsuleCollider _collider;
    private ActionBasedContinuousMoveProvider mvprov;

    // private Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        xrRig = GetComponent<XROrigin>();
        _collider = GetComponent<CapsuleCollider>();
        mvprov = GetComponent<ActionBasedContinuousMoveProvider>();
        sprintActionReference.action.performed += OnSprint;
        Debug.Log(mvprov.moveSpeed);
        // body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var center = xrRig.CameraInOriginSpacePos;
        _collider.center = new Vector3(center.x, _collider.center.y, center.z);
        _collider.height = xrRig.CameraInOriginSpaceHeight;
    }

    private void OnSprint(InputAction.CallbackContext obj)
    {
        Debug.Log("Test");
        mvprov.moveSpeed = 15f;
        Debug.Log(mvprov.moveSpeed);

    }
}
