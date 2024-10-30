using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class InteractableNameText : MonoBehaviour
{
    TextMeshProUGUI text;

    Transform cameraTransform;

    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        cameraTransform = Camera.main.transform;
        HideText();
    }

    public void ShowText(Interactable interactable)
    {
        if (interactable is PickUpItem)
        {
            text.text = interactable.interactableName + "\n [F] Pick Up";
        }
        else if (interactable is Chest)
        {
            if (!((Chest)interactable).isOpen)
            {
                text.text = interactable.interactableName + "\n [F] Open";
            }
        }
        else if (interactable is InteractableNPC)
        {
            text.text = interactable.interactableName + "\n [F] Speak";
        }
        else
        {
            text.text = interactable.interactableName;
        }
    }

    public void HideText()
    {
        text.text = "";
    }

    public void SetInteractableNamePosition(Interactable interactable)
    {
        if (interactable.TryGetComponent(out BoxCollider boxCollider))
        {
            transform.position = interactable.transform.position + Vector3.up * boxCollider.bounds.size.y;
            transform.LookAt(2 * transform.position - cameraTransform.position);
        }
        else if (interactable.TryGetComponent(out CapsuleCollider capsuleCollider))
        {
            transform.position = interactable.transform.position + Vector3.up * capsuleCollider.height;
            transform.LookAt(2 * transform.position - cameraTransform.position);
        }
        else
        {
            Debug.Log("Error");
        }
    }
}
