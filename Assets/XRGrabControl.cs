using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class XRGrabControl : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Rigidbody rb;

    void Awake()
    {
        // Получаем компоненты XRGrabInteractable и Rigidbody
        grabInteractable = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();

        // Отключаем XRGrabInteractable по умолчанию
        if (grabInteractable != null)
        {
            grabInteractable.enabled = false;
        }

        // Замораживаем Rigidbody по умолчанию
        if (rb != null)
        {
            FreezeRigidbody();
        }
    }

    // Метод для активации взаимодействия
    public void EnableGrab()
    {
        if (grabInteractable != null)
        {
            grabInteractable.enabled = true;
        }

        if (rb != null)
        {
            UnfreezeRigidbody();
        }
    }

    // Метод для деактивации взаимодействия
    public void DisableGrab()
    {
        if (grabInteractable != null)
        {
            grabInteractable.enabled = false;
        }

        if (rb != null)
        {
            FreezeRigidbody();
        }
    }

    // Замораживает позицию и поворот Rigidbody
    private void FreezeRigidbody()
    {
        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    // Размораживает позицию и поворот Rigidbody
    private void UnfreezeRigidbody()
    {
        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints.None;
        }
    }
}