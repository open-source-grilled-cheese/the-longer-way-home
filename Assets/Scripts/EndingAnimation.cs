using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingAnimation : MonoBehaviour
{
    private Animator animator;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        AnimationClip blissClip = animator.runtimeAnimatorController.animationClips[1];
        animator.Play("Bliss");
        
        //animator.Play("FlyAway");
        
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
