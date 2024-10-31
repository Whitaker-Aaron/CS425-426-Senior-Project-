using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionRadius = 2.0f;
    [SerializeField] private LayerMask interactableMask;

    private readonly Collider[] colliders = new Collider[3];
    private i_Interactable currentInteractable;

    private void Update()
    {
        // Check for interactable objects within the radius
        int num = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionRadius, colliders, interactableMask);

        if (num > 0)
        {
            // Try to get the first interactable object in range
            i_Interactable interactable = colliders[0].GetComponent<i_Interactable>();
            if (interactable != null)
            {
                // Show UI if we've entered a new interactable object
                if (interactable != currentInteractable)
                {
                    currentInteractable?.HideUi(); // Hide UI of the previous interactable
                    currentInteractable = interactable;
                    currentInteractable.ShowUI();   // Show UI for the new interactable
                }

                // Interaction key check (e.g., 'F')
                if (Keyboard.current.fKey.wasPressedThisFrame)
                {
                    currentInteractable.Interact(this);
                }
            }
        }
        else
        {
            // No interactable objects in range, hide UI and reset reference
            if (currentInteractable != null)
            {
                currentInteractable.HideUi(); // Hide UI when leaving interaction range
                currentInteractable = null;   // Reset interactable reference
            }
        }
    }
}
