using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class CarrierSpringControll : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable carrierSpring;
    [SerializeField] private XRSocketInteractor carrierSpringSocket;

    [SerializeField] private KalashAnimationController kalashAnimationController;

    private void Update()
    {
        if (kalashAnimationController.IsDetentLeverActivate == true )
        {
            carrierSpring.interactionLayers = InteractionLayerMask.GetMask("CarrierSpring");
            carrierSpringSocket.interactionLayers = InteractionLayerMask.GetMask("CarrierSpring");
        }
        else
        {
            if (carrierSpringSocket.hasSelection == true)
            {
                carrierSpring.interactionLayers = InteractionLayerMask.GetMask("XLB");
                carrierSpringSocket.interactionLayers = InteractionLayerMask.GetMask("XLB");
            }
        }
    }
}
