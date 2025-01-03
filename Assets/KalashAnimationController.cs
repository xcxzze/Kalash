using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KalashAnimationController : MonoBehaviour
{
    [SerializeField] private Animator safetyCatchAnimator;
    [SerializeField] private Animator chargingHandleAnimator;
    [SerializeField] private Animator detentLeverAnimator;

    private bool isSafetyActive = false;
    private bool isChargingHandleActive = false;
    private bool isDetentLeverActivate = false;

    public void SafetyСatchAnimation(SelectEnterEventArgs args)     // предохранитель
    {
        if (isChargingHandleActive != true)
        {
            isSafetyActive = !isSafetyActive;
        }

        safetyCatchAnimator.SetBool("IsSafetyActive", isSafetyActive);
    }

    public void ChargingHandleAnimation(SelectEnterEventArgs args)      // рукоятка взведения
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

    private IEnumerator ResetChargingHandleFail()
    {
        // Ждем один кадр, чтобы анимация начала проигрываться
        yield return null;

        // Проверяем состояние анимации
        AnimatorStateInfo animationState;
        do
        {
            animationState = chargingHandleAnimator.GetCurrentAnimatorStateInfo(0);
            yield return null;
        } while (animationState.IsName("ChargingHandleFail") && animationState.normalizedTime < 1.0f);

        // Сбрасываем флаг после завершения анимации
        chargingHandleAnimator.SetBool("IsChargingHandleFail", false);
    }

    public void DetentLeverAnimation(SelectEnterEventArgs args)      // фиксирующий рычаг пылезащитного чехла
    {
        isDetentLeverActivate = !isDetentLeverActivate;

        detentLeverAnimator.SetBool("IsDetentLeverActivate", isDetentLeverActivate);
    }

}