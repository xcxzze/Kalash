using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class KalashAnimationController : MonoBehaviour
{
    [SerializeField] private XRSocketInteractor socketInteractorDustCover;

    [SerializeField] private XRGrabControl dustCover�ontrol;

    [SerializeField] private Animator safetyCatchAnimator;
    [SerializeField] private Animator chargingHandleAnimator;
    [SerializeField] private Animator detentLeverAnimator;

    private bool isSafetyActive = false;
    private bool isChargingHandleActive = false;
    private bool isDetentLeverActivate = false;

    public bool IsDetentLeverActivate => isDetentLeverActivate;

    public void Safety�atchAnimation(SelectEnterEventArgs args)     // ��������������
    {
        if (isChargingHandleActive != true)
        {
            isSafetyActive = !isSafetyActive;
        }

        safetyCatchAnimator.SetBool("IsSafetyActive", isSafetyActive);
    }

    public void ChargingHandleAnimation(SelectEnterEventArgs args)      // �������� ���������
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

    public void DetentLeverAnimation(SelectEnterEventArgs args)      // ����������� ����� ������������� �����
    {
        isDetentLeverActivate = !isDetentLeverActivate;

        if (isDetentLeverActivate == true)
        {
            dustCover�ontrol.EnableGrab();
        }
        
        if (socketInteractorDustCover.hasSelection == true && isDetentLeverActivate == false)
        {
            dustCover�ontrol.DisableGrab();
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