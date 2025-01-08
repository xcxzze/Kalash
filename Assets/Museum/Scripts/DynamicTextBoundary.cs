using TMPro;
using UnityEngine;

public class DynamicTextBoundary : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    private RectTransform panel;

    void Start()
    {
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        panel = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (textMeshPro != null && panel != null)
        {
            float textHeight = textMeshPro.preferredHeight;
            Vector2 panelSize = panel.sizeDelta;
            panelSize.y = textHeight;
            panel.sizeDelta = panelSize;
        }
    }
}