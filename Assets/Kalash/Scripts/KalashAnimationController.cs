using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KalashAnimationController : MonoBehaviour
{
    [SerializeField] private XRGrabControl dustCover�ontrol;

    [SerializeField] private Animator safetyCatchAnimator;
    [SerializeField] private Animator chargingHandleAnimator;
    [SerializeField] private Animator detentLeverAnimator;

    private bool isSafetyActive = false;
    private bool isChargingHandleActive = false;
    private bool isDetentLeverActivate = false;

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

        detentLeverAnimator.SetBool("IsDetentLeverActivate", isDetentLeverActivate);

        if (isDetentLeverActivate == true)
        {
            dustCover�ontrol.EnableGrab();
        }
        else
        {
            dustCover�ontrol.DisableGrab();
        }
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