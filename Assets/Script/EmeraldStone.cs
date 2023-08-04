using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmeraldStone : MonoBehaviour
{
    public GameObject emeraldStone;
    public GameController gameController;

    public void OnTriggerStay()
    {
        if (Input.GetMouseButton(0))
        {
           emeraldStone.SetActive(false);
           gameController.GettingTheSecret();
        }
    }
}
