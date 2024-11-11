using UnityEngine;

public class CameraAnimationTrigger : MonoBehaviour
{
    private Animation cameraAnimation;
    private bool hasPlayed = false;  // Flag to ensure the animation only plays once

    void Start()
    {
        // Get the Animation component attached to the camera
        cameraAnimation = GetComponent<Animation>();

        if (cameraAnimation == null)
        {
            Debug.LogError("Animation component not found on the camera. Please add an Animation component.");
        }
    }

    void Update()
    {
        // Check if the Spacebar is pressed and the animation hasn't been played yet
        if (Input.GetKeyDown(KeyCode.Space) && !hasPlayed)
        {
            // Play the animation if it's not already playing and mark it as played
            if (cameraAnimation != null && !cameraAnimation.isPlaying)
            {
                cameraAnimation.Play();
                hasPlayed = true;  // Set the flag to true, so the animation only plays once
            }
        }
    }
}
