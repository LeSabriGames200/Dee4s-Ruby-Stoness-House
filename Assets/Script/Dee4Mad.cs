using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Dee4Mad : MonoBehaviour
{

    public NavMeshAgent Dee4;
    public Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Dee4.SetDestination(Player.position);
    }

    public void OnTriggerEnter()
    {
        SceneManager.LoadScene("GameOver");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameController.RubyStonesCollected = 0;
    }
}
