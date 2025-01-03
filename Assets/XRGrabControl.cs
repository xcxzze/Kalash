using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class XRGrabControl : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Rigidbody rb;

    void Awake()
    {
        // �������� ���������� XRGrabInteractable � Rigidbody
        grabInteractable = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();

        // ��������� XRGrabInteractable �� ���������
        if (grabInteractable != null)
        {
            grabInteractable.enabled = false;
        }

        // ������������ Rigidbody �� ���������
        if (rb != null)
        {
            FreezeRigidbody();
        }
    }

    // ����� ��� ��������� ��������������
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

    // ����� ��� ����������� ��������������
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

    // ������������ ������� � ������� Rigidbody
    private void FreezeRigidbody()
    {
        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    // ������������� ������� � ������� Rigidbody
    private void UnfreezeRigidbody()
    {
        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints.None;
        }
    }
}