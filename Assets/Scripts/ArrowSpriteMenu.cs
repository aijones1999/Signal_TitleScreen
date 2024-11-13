using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverArrow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Arrow Settings")]
    public Image arrowImage;           // Reference to the arrow sprite
    public Vector2 offset = new Vector2(-50f, 0f); // Offset of the arrow from the button position

    private void Start()
    {
        // Ensure the arrow image is initially hidden
        if (arrowImage != null)
        {
            arrowImage.gameObject.SetActive(false);
        }
    }

    // Triggered when the mouse pointer enters the button
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (arrowImage != null)
        {
            // Activate the arrow image
            arrowImage.gameObject.SetActive(true);

            // Set the arrow position relative to this button's position, using the offset
            RectTransform buttonRect = GetComponent<RectTransform>();
            arrowImage.rectTransform.position = buttonRect.position + (Vector3)offset;
        }
    }

    // Triggered when the mouse pointer exits the button
    public void OnPointerExit(PointerEventData eventData)
    {
        // Hide the arrow when exiting the button
        if (arrowImage != null)
        {
            arrowImage.gameObject.SetActive(false);
        }
    }
}
