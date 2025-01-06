using System.Collections;
using TMPro;
using UnityEngine;

public class OutlineControl : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private OutlinableManager outlinableManager;
    [SerializeField] private TMP_Text textPanel;
    [SerializeField] private Outlinable lastChosenDetail;

    private void Start()
    {
        panel.SetActive(false);
        StartCoroutine(DisableOutlineAfterDelay());
    }

    public void EnableOutline()
    {
        if (gameObject.CompareTag("Outlinable"))
        {
            var selectedDetail = outlinableManager.FindOutlinableByName(gameObject.name);

            outlinableManager.SwitchOutline(selectedDetail);
        }
    }

    public void DisableOutline()
    {
        if (gameObject.CompareTag("Outlinable"))
        {
            var selectedDetail = outlinableManager.FindOutlinableByName(gameObject.name);

            outlinableManager.SwitchOutline(selectedDetail);
        }
    }

    public void ClickOutline()
    {
        if (gameObject.CompareTag("Outlinable"))
        {
            var selectedDetail = outlinableManager.FindOutlinableByName(gameObject.name);

            if (selectedDetail != null)
            {
                selectedDetail.outline.OutlineColor = Color.green;
                selectedDetail.isChangable = false;
                selectedDetail.outline.enabled = true;

                if (lastChosenDetail != null)
                {
                    lastChosenDetail.outline.OutlineColor = lastChosenDetail.color;
                    lastChosenDetail.isChangable = true;
                    lastChosenDetail.outline.enabled = false;

                    if (lastChosenDetail == selectedDetail)
                    {
                        lastChosenDetail.isOnceUnchangable = true;
                        lastChosenDetail = null;
                        panel.SetActive(false);

                        return;
                    }
                }
                textPanel.text = selectedDetail.info;
                lastChosenDetail = selectedDetail;
                panel.SetActive(true);
            }
        }
        else
        {
            if (lastChosenDetail != null)
            {
                lastChosenDetail.outline.OutlineColor = lastChosenDetail.color;
                lastChosenDetail.isChangable = true;
                lastChosenDetail.outline.enabled = false;

                lastChosenDetail = null;
                panel.SetActive(false);
            }
        }
    }

    public IEnumerator DisableOutlineAfterDelay()
    {
        yield return new WaitForSeconds(0.01f);
        DisableOutline();
    }
}
