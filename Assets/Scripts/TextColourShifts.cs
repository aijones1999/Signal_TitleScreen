using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required for event handling

public class SimpleTextColorChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Editable colors in the Inspector
    public Color normalColor = Color.white;
    public Color highlightColor = Color.green;
    public Color pressedColor = Color.red;

    private TextMeshProUGUI textMeshPro;

    void Start()
    {
        // Get the TextMeshProUGUI component attached to this GameObject
        textMeshPro = GetComponent<TextMeshProUGUI>();

        // Set the initial color of the text
        if (textMeshPro != null)
        {
            textMeshPro.color = normalColor;
        }

        // Add listener for button interactions (if the text is part of a button)
        Button button = GetComponentInParent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnClick);
        }
    }

    // Called when the mouse hovers over the text
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (textMeshPro != null)
        {
            textMeshPro.color = highlightColor; // Change color when hovered
        }
    }

    // Called when the mouse exits the text area
    public void OnPointerExit(PointerEventData eventData)
    {
        if (textMeshPro != null)
        {
            textMeshPro.color = normalColor; // Revert color when mouse exits
        }
    }

    // Called when the button is clicked
    void OnClick()
    {
        if (textMeshPro != null)
        {
            textMeshPro.color = pressedColor; // Change color when clicked
        }
    }
}
