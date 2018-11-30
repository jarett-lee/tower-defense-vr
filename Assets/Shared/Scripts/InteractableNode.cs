//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: Demonstrates how to create a simple interactable object
//
//=============================================================================

using UnityEngine;
using System.Collections;
using Valve.VR.InteractionSystem;

//-------------------------------------------------------------------------
[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(TempNode))]
public class InteractableNode : MonoBehaviour
{
    private Interactable interactable;
    private TempNode node;

    //-------------------------------------------------
    void Awake()
    {
        interactable = GetComponent<Interactable>();
        node = GetComponent<TempNode>();
    }


    //-------------------------------------------------
    // Called when a Hand starts hovering over this object
    //-------------------------------------------------
    private void OnHandHoverBegin(Hand hand)
    {
        // Display turret above node
    }


    //-------------------------------------------------
    // Called when a Hand stops hovering over this object
    //-------------------------------------------------
    private void OnHandHoverEnd(Hand hand)
    {
        // Hide turret above node
    }


    //-------------------------------------------------
    // Called every Update() while a Hand is hovering over this object
    //-------------------------------------------------
    private void HandHoverUpdate(Hand hand)
    {
        GrabTypes startingGrabType = hand.GetGrabStarting();

        if (interactable.attachedToHand == null && startingGrabType != GrabTypes.None)
        {
            // Build turret
            node.BuildTurret();
        }
    }
}
