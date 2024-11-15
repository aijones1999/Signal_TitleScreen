using UnityEngine;

public class PlayNextAnimationOnce : MonoBehaviour
{
    private Animator animator;
    private bool animationPlayed = false;

    void Start()
    {

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && !animationPlayed)
        {
        
            animator.SetTrigger("NextAnimationTrigger");

     
            animationPlayed = true;
        }
    }
}
