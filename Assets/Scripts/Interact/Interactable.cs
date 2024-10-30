using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Interactable : MonoBehaviour
{
    [Header("Interaction Data")]
    public string interactableName = " ";
    public float interactionDistance = 2;
    [SerializeField] bool isInteractable = true;

    InteractableNameText interactableNameText;
    GameObject interactableNameCanvas;

    public virtual void Start()
    {
        interactableNameCanvas = GameObject.FindGameObjectWithTag("Canvas");

        if (interactableNameCanvas != null)
        {
            interactableNameText = interactableNameCanvas.GetComponentInChildren<InteractableNameText>();
        }
        else
        {
            Debug.LogWarning("Canvas with the InteractableNameText component not found.");
        }
    }

    public void TargetOn()
    {
        if (interactableNameText != null)
        {
            interactableNameText.ShowText(this);
            interactableNameText.SetInteractableNamePosition(this);
        }
        else
        {
            Debug.LogWarning("InteractableNameText component is missing.");
        }
    }

    public void TargetOff()
    {
        if (interactableNameText != null)
        {
            interactableNameText.HideText();
        }
    }

    public void Interact()
    {
        if (isInteractable) Interaction();
    }

    protected virtual void Interaction()
    {
        // Custom interaction logic here
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, interactionDistance);
    }

    private void OnDestroy()
    {
        TargetOff();
    }
}
