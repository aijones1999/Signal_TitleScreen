using UnityEngine;
using UnityEngine.UI;

public class VolumeHandleVisual : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;  // Reference to the UI slider
    [SerializeField] private Transform handleTransform;  // Reference to the 3D handle's transform
    [SerializeField] private Vector3 localStartPosition;  // Local starting position for the handle
    [SerializeField] private Vector3 localEndPosition;    // Local ending position for the handle

    private void Start()
    {
        // Set the initial position based on the slider's starting value
        UpdateHandlePosition(volumeSlider.value);

        // Add a listener for the slider's value changes
        volumeSlider.onValueChanged.AddListener(UpdateHandlePosition);
    }

    private void UpdateHandlePosition(float sliderValue)
    {
        // Interpolate between local start and end positions
        handleTransform.localPosition = Vector3.Lerp(localStartPosition, localEndPosition, sliderValue);
    }

    private void OnDestroy()
    {
        // Remove the listener to prevent memory leaks
        volumeSlider.onValueChanged.RemoveListener(UpdateHandlePosition);
    }
}
