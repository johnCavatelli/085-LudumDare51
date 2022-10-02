using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public static interactionStates interactionState;
    public float interactionDistance;
    public LayerMask interactionMask;
    public Transform playerViewCamera;
    public TextManager textManager;

    private GameObject hoveredInteractable;

    private void Start()
    {
        interactionState = interactionStates.freeRoam;
    }
    private void Update()
    {
        switch (interactionState)
        {
            case interactionStates.freeRoam:
                if (IsHoveringOverInteractable())
                {
                    UpdateTip();
                    if(Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
                    {
                        Interact(hoveredInteractable.GetComponent<Interactable>());
                    }
                }
                else
                {
                    ClearTip();
                }
                break;
            case interactionStates.inInteraction:
                if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
                {
                    if (TextManager.current.AttemptProgressInteraction())
                    {
                        interactionState = interactionStates.freeRoam;
                    }
                }
                break;
            case interactionStates.paused:
                break;
            default:
                break;
        }
    }

    private void Interact(Interactable interactable)
    {
        if(interactable is HumanInteraction)
        {
            //print("IS HUMAN INTERACTION");
            interactionState = interactionStates.inInteraction;
            ClearTip();
        }
        interactable.Interact();
    }

    private void UpdateTip()
    {
        if (hoveredInteractable != null)
        {
            textManager.UpdateTipText(hoveredInteractable.GetComponent<Interactable>().getTipText());
        }
        else
        {
            Debug.LogWarning("Trying to update tip of something empty");
        }
    }

    private void ClearTip()
    {
        textManager.ClearTipText();
    }

    private bool IsHoveringOverInteractable()
    {
        RaycastHit hit;
        if(Physics.Raycast(playerViewCamera.position,playerViewCamera.forward, out hit, interactionDistance, interactionMask))
        {
            hoveredInteractable = hit.transform.gameObject;
            //print("Hovering Over Interactable");
            return true;
        }
        return false;
    }
}

public enum interactionStates
{
    freeRoam, inInteraction, paused
}
