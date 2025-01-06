using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class XRGrabControl : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Rigidbody rigidbody;
    private OutlineControlKalash outlineControl;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        rigidbody = GetComponent<Rigidbody>();
        outlineControl = GetComponent<OutlineControlKalash>();

        DisableGrab();
    }

    public void EnableGrab()
    {
        grabInteractable.enabled = true;
        StartCoroutine(outlineControl.DisableOutlineAfterDelay());

        rigidbody.constraints = RigidbodyConstraints.None;
    }

    public void DisableGrab()
    {
        grabInteractable.enabled = false;
        rigidbody.constraints = RigidbodyConstraints.FreezeAll;
    }
}