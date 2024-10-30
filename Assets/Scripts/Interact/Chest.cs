using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    private Animator animator;
    [Header("Locked Chest Options")]
    public bool isLocked;
    public string chestID;
    public bool isOpen;

    public override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        isOpen = false;
    }

    protected override void Interaction()
    {
        base.Interaction();

        if (!isLocked)
        {
            if (!isOpen)
            {
                OpenChest();
                Debug.Log("Opening the Chest");
            }
            else
            {
                Debug.Log("Chest is already open");
            }
        }
        else
        {
            //This is where we would use a specific key
            //Check the chest ID with the Key ID
        }
    }

    void OpenChest()
    {
        animator.SetTrigger("Open Chest");
        isOpen = !isOpen;
    }
}
