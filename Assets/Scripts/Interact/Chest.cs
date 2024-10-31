using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, i_Interactable
{
    [SerializeField] private string prompt;

    private Animator animator;

    [Header("Locked Chest Options")]
    public bool isLocked;
    public string chestID;
    public bool isOpen;
    public GameObject chestUI;

    public string interactionPrompt => prompt;

    public void Start()
    { 
        isOpen = false;
    }

    public bool Interact(Interactor interactor)
    {
        if (!isLocked)
        {
            if (isOpen == false)
            {
                Debug.Log("Opening the Chest");
                isOpen = true;
            }
            else
            {
                Debug.Log("Chest is already open");
            }
        }
        else
        {
            
            Debug.Log("Chest is locked");
        }

        return true;
    }

    public void ShowUI()
    {
        if (chestUI != null)
        {
            chestUI.SetActive(true);
        }
    }
    public void HideUi()
    {
        if (chestUI != null)
        {
            chestUI.SetActive(false);
        }
    }
}
