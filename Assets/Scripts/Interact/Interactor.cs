using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class Interactor : MonoBehaviour
{
    [SerializeField] float maxInteractingDistance = 10;
    [SerializeField] float interactingRadius = 1;

    LayerMask layerMask;
    Transform cameraTransform;
    InputAction interactAction;

    Vector3 origin;
    Vector3 direction;
    Vector3 hitPosition;
    float hitDistance;

    [HideInInspector] public Interactable interactableTarget;

    void Start()
    {
        if (Camera.main != null)
            cameraTransform = Camera.main.transform;

        layerMask = LayerMask.GetMask("Outline", "Enemy", "NPC");

        interactAction = GetComponent<PlayerInput>().actions["Interact"];
        interactAction.performed += Interact;
    }

    void Awake()
    {
        if (Camera.main != null && cameraTransform == null)
            cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        // Check if cameraTransform is null
        if (cameraTransform == null)
        {
            Debug.LogWarning("Camera transform is missing.");
            return; // Exit Update if no camera is present
        }

        direction = cameraTransform.forward;
        origin = cameraTransform.position;
        RaycastHit hit;

        if (Physics.SphereCast(origin, interactingRadius, direction, out hit, maxInteractingDistance, layerMask))
        {
            hitPosition = hit.point;
            hitDistance = hit.distance;
            if (hit.transform.TryGetComponent<Interactable>(out interactableTarget))
            {
                interactableTarget.TargetOn();
            }
        }
        else if (interactableTarget != null)
        {
            interactableTarget.TargetOff();
            interactableTarget = null;
        }
    }

    private void Interact(InputAction.CallbackContext obj)
    {
        if (interactableTarget != null)
        {
            if (Vector3.Distance(transform.position, interactableTarget.transform.position) <= interactableTarget.interactionDistance)
            {
                interactableTarget.Interact();
            }
        }
        else
        {
            Debug.Log("Nothing to Interact with!");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(origin, origin + direction * hitDistance);
        Gizmos.DrawWireSphere(hitPosition, interactingRadius);
    }

    private void OnDestroy()
    {
        if (interactAction != null)
        {
            interactAction.performed -= Interact;
        }
    }
}
