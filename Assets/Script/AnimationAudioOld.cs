using UnityEngine;

public class AnimationAudioOld : MonoBehaviour
{
    public AudioSource audioSource;
    public Animation animation;

    private void Start()
    {
        // Get references to the AudioSource and Animation components
        audioSource = GetComponent<AudioSource>();
        animation = GetComponent<Animation>();

        // Play the audio clip
        audioSource.Play();

        // Play the animation
        animation.Play();
    }

    private void Update()
    {
        // Check if the audio clip has finished playing
        if (!audioSource.isPlaying)
        {
            // Stop the animation
            animation.Stop();
        }
    }
}
