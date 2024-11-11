using UnityEngine;
using UnityEngine.EventSystems; // Required for EventTrigger functionality
using System.Collections;

public class PushButtonEffect : MonoBehaviour
{
    [Header("UI Screens to Trigger Effect On")]
    public GameObject[] uiScreens;  // List of screens to check for activity
    public AudioClip pressSound;    // Sound effect to play when pressed
    public float pushDistance = 0.2f; // How far to push the mesh along the Z-axis
    public float pushDuration = 0.1f; // Time taken to push in and back out
    public float soundVolume = 1f;   // Volume of the press sound (range: 0 to 1)

    private Vector3 originalPosition;
    private AudioSource audioSource;
    private bool isPushed = false;   // To ensure the button is only pushed once per click

    void Start()
    {
        // Store the original position to return to it later
        originalPosition = transform.position;

        // Get or add an AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.volume = soundVolume;
    }

    // Function triggered by the EventTrigger's PointerClick event
    public void OnButtonClicked()
    {
        // Start the push effect only if not already pushed
        if (!isPushed)
        {
            StartCoroutine(PushInAndOut());
        }
    }

    // Coroutine to smoothly push the button in and then back out
    private IEnumerator PushInAndOut()
    {
        isPushed = true;

        // Calculate the target position (pushed-in position)
        Vector3 pushedPosition = originalPosition + new Vector3(0f, 0f, -pushDistance);

        // Smoothly move to the pushed position
        float elapsedTime = 0f;
        while (elapsedTime < pushDuration)
        {
            transform.position = Vector3.Lerp(originalPosition, pushedPosition, elapsedTime / pushDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = pushedPosition;

        // Play the press sound when pushed in
        if (audioSource != null && pressSound != null)
        {
            audioSource.PlayOneShot(pressSound, soundVolume);
        }

        // Wait briefly before moving back to the original position
        yield return new WaitForSeconds(pushDuration);

        // Smoothly move back to the original position
        elapsedTime = 0f;
        while (elapsedTime < pushDuration)
        {
            transform.position = Vector3.Lerp(pushedPosition, originalPosition, elapsedTime / pushDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = originalPosition;

        // Reset the flag to allow another push
        isPushed = false;
    }
}
