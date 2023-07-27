using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spee8Mechanic : MonoBehaviour
{

    public Player player;
    public AudioSource audiosource;

    public void Start()
    {
        player.walkingSpeed = 10;
        player.runningSpeed = 20;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.walkingSpeed = 20;
            player.runningSpeed = 36;
            audiosource.Play();
            StartCoroutine("PlayerSlow");
        }
    }

    IEnumerator PlayerSlow()
    {
        yield return new WaitForSeconds(15);
        player.walkingSpeed = 10;
        player.runningSpeed = 20;
    }
}
