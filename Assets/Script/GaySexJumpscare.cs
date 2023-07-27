using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaySexJumpscare : MonoBehaviour
{
    public GameObject GaySex;
    public AudioSource GAYJUMPSCARE;

    public void OnTriggerEnter() 
    {
        GaySex.SetActive(true);
        GAYJUMPSCARE.Play();
        StartCoroutine(RemoveJumpscare());
    }

    IEnumerator RemoveJumpscare() 
    {
        yield return new WaitForSeconds(5);
        GaySex.SetActive(false);
    }
}
