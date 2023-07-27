using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyStones : MonoBehaviour
{
    public GameObject RubyStone;

    public void OnTriggerStay() 
    {
        if (Input.GetMouseButton(0)) 
        {
            RubyStone.SetActive(false);
            GameController gameController = FindObjectOfType<GameController>();
            if (gameController != null)
            {
                gameController.CollectRubyStone();
            }
        }
    }
}

