using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class KalashAnimationController : MonoBehaviour
{
    [SerializeField] private XRSocketInteractor socketInteractorDustCover;

    [SerializeField] private XRGrabControl dustCoverÑontrol;

    [SerializeField] private Animator safetyCatchAnimator;
    [SerializeField] private Animator chargingHandleAnimator;
    [SerializeField] private Animator detentLeverAnimator;

    private bool isSafetyActive = false;
    private bool isChargingHandleActive = false;
    private bool isDetentLeverActivate = false;

    public bool IsDetentLeverActivate => isDetentLeverActivate;

    public void SafetyÑatchAnimation(SelectEnterEventArgs args)     // ïğåäîõğàíèòåëü
    {
        if (isChargingHandleActive != true)
        {
            isSafetyActive = !isSafetyActive;
        }

        safetyCatchAnimator.SetBool("IsSafetyActive", isSafetyActive);
    }

    public void ChargingHandleAnimation(SelectEnterEventArgs args)      // ğóêîÿòêà âçâåäåíèÿ
    {
        if (isSafetyActive == false)
        {
            chargingHandleAnimator.SetBool("IsChargingHandleFail", true);
            StartCoroutine(ResetChargingHandleFail());
        }
        else
        {
            isChargingHandleActive = !isChargingHandleActive;
            
            chargingHandleAnimator.SetBool("IsChargingHandleActive", isChargingHandleActive);
        }
    }

    public void DetentLeverAnimation(SelectEnterEventArgs args)      // ôèêñèğóşùèé ğû÷àã ïûëåçàùèòíîãî ÷åõëà
    {
        isDetentLeverActivate = !isDetentLeverActivate;

        if (isDetentLeverActivate == true)
        {
            dustCoverÑontrol.EnableGrab();
        }
        
        if (socketInteractorDustCover.hasSelection == true && isDetentLeverActivate == false)
        {
            dustCoverÑontrol.DisableGrab();
        }
        else
        {
            isDetentLeverActivate = true;
        }

        detentLeverAnimator.SetBool("IsDetentLeverActivate", isDetentLeverActivate);
    }

    private IEnumerator ResetChargingHandleFail()
    {
        yield return null;

        AnimatorStateInfo animationState;

        do
        {
            animationState = chargingHandleAnimator.GetCurrentAnimatorStateInfo(0);
            yield return null;
        }
        while (animationState.IsName("ChargingHandleFail") && animationState.normalizedTime < 1.0f);
        {
            chargingHandleAnimator.SetBool("IsChargingHandleFail", false);
        }
    }
}