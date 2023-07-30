using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour
{

    public GameController gameController;

    public void OnTriggerEnter() 
    {
        SceneManager.LoadScene("Won");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if (gameController.GetSecret)
        {
            SceneManager.LoadScene("Secret");
        }
        else
        {
            SceneManager.LoadScene("Won");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
