using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ChangingImplementationsChargingHandle : MonoBehaviour
{
    [SerializeField] private GameObject chargingHandleAnimation;
    [SerializeField] private GameObject chargingHandleGrab;
    [SerializeField] private GameObject chargingHandleSocket;

    [SerializeField] private GameObject carrierSpringSocket;
    
    private XRSocketInteractor socketInteractorCarrierSpring;
    private XRSocketInteractor socketInteractorChargingHandle;

    private void Start()
    {
       socketInteractorCarrierSpring = carrierSpringSocket.GetComponent<XRSocketInteractor>();
       socketInteractorChargingHandle = chargingHandleSocket.GetComponent<XRSocketInteractor>();
    }

    private void Update()
    {
        if (socketInteractorCarrierSpring.hasSelection == false)
        {
            chargingHandleAnimation.SetActive(false);
            chargingHandleGrab.SetActive(true);
            chargingHandleSocket.SetActive(true);
        }
        else
        {
            if (socketInteractorChargingHandle.hasSelection == true)
            {
                chargingHandleAnimation.SetActive(true);
                chargingHandleGrab.SetActive(false);
                chargingHandleSocket.SetActive(false);
            }
            else
            {
                chargingHandleSocket.gameObject.SetActive(false);
            }
        }
    }
}
