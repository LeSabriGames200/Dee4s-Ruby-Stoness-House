using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dededede8888Mechanic : MonoBehaviour
{

    public Player player;

    public void Start()
    {
        player.walkingSpeed = 10;
        player.runningSpeed = 20;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player.walkingSpeed = 0;
            player.runningSpeed = 0;
            StartCoroutine("PlayerMovingAgain");
        }
    }

    IEnumerator PlayerMovingAgain()
    {
        yield return new WaitForSeconds(5);
        player.walkingSpeed = 10;
        player.runningSpeed = 20;
    }
}
