using UnityEngine;
using UnityEngine.EventSystems;

public class BlockInputWhileAnimating : MonoBehaviour
{
    [SerializeField] private Animation animationComponent; // Reference to the Animation component
    [SerializeField] private string animationClipName;      // Name of the animation clip to monitor
    [SerializeField] private Canvas canvas;                // The Canvas that handles UI input
    [SerializeField] private EventSystem eventSystem;      // The EventSystem that handles input events

    private bool isInputBlocked = false;

    void Start()
    {
        // Ensure that the Animation component is assigned
        if (animationComponent == null)
        {
            animationComponent = GetComponent<Animation>();
            if (animationComponent == null)
            {
                Debug.LogError("No Animation component found on the GameObject!");
                return;
            }
        }

        // Ensure the canvas and event system are assigned
        if (canvas == null || eventSystem == null)
        {
            Debug.LogError("Canvas or EventSystem not assigned!");
            return;
        }
    }

    void Update()
    {
        // Check if the animation is currently playing
        if (animationComponent.IsPlaying(animationClipName))
        {
            if (!isInputBlocked)
            {
                BlockInput();
            }
        }
        else
        {
            if (isInputBlocked)
            {
                UnblockInput();
            }
        }
    }

    private void BlockInput()
    {
        // Block input by disabling the EventSystem
        isInputBlocked = true;

        // Disable the EventSystem and Canvas to prevent any UI input
        eventSystem.enabled = false;
        canvas.enabled = false;

        // Optionally, lock the cursor to prevent mouse movement
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Debug.Log("Input is blocked during animation.");
    }

    private void UnblockInput()
    {
        // Unblock input by enabling the EventSystem and Canvas
        isInputBlocked = false;

        eventSystem.enabled = true;
        canvas.enabled = true;

        // Unlock the cursor and make it visible again
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Debug.Log("Input is unblocked after animation.");
    }

    public void PlayAnimation()
    {
        // Play the animation and block input
        if (animationComponent != null && animationComponent[animationClipName] != null)
        {
            animationComponent.Play(animationClipName);
        }
        else
        {
            Debug.LogError($"Animation clip '{animationClipName}' not found on the Animation component.");
        }
    }
}
