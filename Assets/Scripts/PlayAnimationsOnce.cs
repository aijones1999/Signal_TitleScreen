using UnityEngine;

public class PlayNextAnimationOnce : MonoBehaviour
{
    private Animator animator;
    private bool animationPlayed = false;

    void Start()
    {
        // Get the Animator component attached to this GameObject
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check for spacebar press and if the animation hasn't already been triggered
        if (Input.GetKeyDown(KeyCode.Space) && !animationPlayed)
        {
            // Set the trigger parameter to play the next animation
            animator.SetTrigger("NextAnimationTrigger");

            // Set flag to true to prevent retriggering
            animationPlayed = true;
        }
    }
}
