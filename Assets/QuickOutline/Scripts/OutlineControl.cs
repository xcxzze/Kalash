using UnityEngine;
using System.Collections;

public class OutlineControl : MonoBehaviour
{
    private Outline outline;

    private void Start()
    {
        outline = GetComponent<Outline>();
        StartCoroutine(DisableOutlineAfterDelay());
    }

    public void EnableOutline()
    {
        outline.enabled = true;
    }

    public void DisableOutline()
    {
        outline.enabled = false;
    }

    public IEnumerator DisableOutlineAfterDelay()
    {
        yield return new WaitForSeconds(0.01f);
        DisableOutline();
    }
}
