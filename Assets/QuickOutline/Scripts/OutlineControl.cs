using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OutlineControl : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private OutlinableManager outlinableManager;

    private TMP_Text textPanel;
    private Outlinable lastChosenDetail;

    private void Start()
    {
        panel.SetActive(false);
        textPanel = panel.GetComponentInChildren<TMP_Text>();
    }

    private void Update()
    {
        //Debug.Log(lastChosenDetail);
    }

    public void OnHoverEntered(HoverEnterEventArgs args)
    {
        HandleHover(args.interactableObject.transform.gameObject, true);
    }

    public void OnHoverExited(HoverExitEventArgs args)
    {
        HandleHover(args.interactableObject.transform.gameObject, false);
    }

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        HandleSelection(args.interactableObject.transform.gameObject);
    }

    private void HandleHover(GameObject target, bool isHovering)
    {
        if (target.CompareTag("Outlinable"))
        {
            var outlinable = outlinableManager.FindOutlinableByName(target.name);
            if (outlinable != null)
            {
                outlinableManager.SwitchOutline(outlinable);
            }
        }
    }

    private void HandleSelection(GameObject target)
    {
        if (target.CompareTag("Outlinable"))
        {
            var selectedDetail = outlinableManager.FindOutlinableByName(target.name);

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
}