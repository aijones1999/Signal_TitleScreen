using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverArrow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Arrow Settings")]
    public RectTransform arrowImage;           // Reference to the arrow sprite (RectTransform)
    public Vector2 offset = new Vector2(-50f, 0f); // Offset of the arrow relative to the button's local position

    private RectTransform originalParent; // Original parent to reattach the arrow when not hovering

    private void Start()
    {
        if (arrowImage != null)
        {
            arrowImage.gameObject.SetActive(false); // Hide arrow initially
            originalParent = arrowImage.parent as RectTransform; // Save the arrow's original parent
        }
    }

    // Called when the mouse pointer enters the button
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (arrowImage != null)
        {
            arrowImage.gameObject.SetActive(true);

            // Set the arrow as a child of the button to lock it to the button’s local position
            arrowImage.SetParent(transform, false);

            // Set the local position of the arrow with the offset
            arrowImage.localPosition = offset;
        }
    }

    // Called when the mouse pointer exits the button
    public void OnPointerExit(PointerEventData eventData)
    {
        if (arrowImage != null)
        {
            // Hide the arrow and reset its parent back to the original
            arrowImage.gameObject.SetActive(false);
            arrowImage.SetParent(originalParent, false);
        }
    }
}
