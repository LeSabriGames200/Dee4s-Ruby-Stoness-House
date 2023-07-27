using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAudio : MonoBehaviour
{
    public AudioSource audio;
    public Animator animator;
    public string noAnimationName;
    public string AnimationName;

    // Start is called before the first frame update
    void Start()
    {
        animator.Play(noAnimationName);
    }

    // Update is called once per frame
    void Update()
    {
        if (audio.isPlaying)
        {
            animator.Play(AnimationName);
        }else
        {
            animator.Play(noAnimationName);
        }
    }
}
