using UnityEngine;
using UnityEngine.EventSystems; // Required for EventTrigger functionality

public class RotateMeshOnButtonHighlight : MonoBehaviour
{
    [Header("UI Screens to Rotate Mesh On")]
    public GameObject[] uiScreens;  // List of screens to check for activity
    public AudioClip rotationSound;  // Sound effect to play when rotation occurs
    public float rotationAmount = 30f; // Amount of rotation per highlight (in degrees)
    public float soundVolume = 1f; // Volume of the rotation sound (range: 0 to 1)

    private MeshRenderer meshRenderer;
    private AudioSource audioSource;

    void Start()
    {
        // Get references to necessary components
        meshRenderer = GetComponent<MeshRenderer>();
        audioSource = GetComponent<AudioSource>();

        // Ensure AudioSource is attached
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Set the initial volume for the audio source based on the soundVolume
        audioSource.volume = soundVolume;

        // Start with no rotation
        meshRenderer.transform.rotation = Quaternion.identity;
    }

    // Function triggered by the EventTrigger's PointerEnter event
    public void OnButtonHighlighted()
    {
        Debug.Log("Button Highlighted");

        // Only rotate the mesh by the specified amount (rotationAmount)
        meshRenderer.transform.Rotate(0f, 0f, rotationAmount);

        // Play the rotation sound when the button is highlighted
        if (audioSource != null && rotationSound != null)
        {
            audioSource.PlayOneShot(rotationSound, soundVolume); // Use soundVolume here
        }
    }

    // Function triggered by the EventTrigger's PointerExit event
    public void OnPointerExit()
    {
        Debug.Log("Pointer Exited");

        // Optionally, you can add logic here to reset or stop rotation, but for now, we are only rotating on button highlight.
    }
}



