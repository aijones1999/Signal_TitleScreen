using UnityEngine;

public class CameraAnimationTrigger : MonoBehaviour
{
    private Animation cameraAnimation;
    private bool hasPlayed = false;  

    void Start()
    {
        
        cameraAnimation = GetComponent<Animation>();

        if (cameraAnimation == null)
        {
            Debug.LogError("Animation component not found on the camera. Please add an Animation component.");
        }
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && !hasPlayed)
        {
            
            if (cameraAnimation != null && !cameraAnimation.isPlaying)
            {
                cameraAnimation.Play();
                hasPlayed = true;  
            }
        }
    }
}
