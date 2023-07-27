using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour
{
    public void OnTriggerEnter() 
    {
        SceneManager.LoadScene("Won");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
