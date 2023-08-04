using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnknowedDeez : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip message;

    public void Start()
    {
        GetComponent<Collider>().enabled = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        audioSource.PlayOneShot(message);
        GetComponent<Collider>().enabled = false;
    }

    public void Update()
    {
        if (audioSource.isPlaying)
        {
            StartCoroutine(GameCrash());
        }
    }
    IEnumerator GameCrash()
    {
        yield return new WaitForSeconds(message.length);
        Application.Quit();
    }
}
