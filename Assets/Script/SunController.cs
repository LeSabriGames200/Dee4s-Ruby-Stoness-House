using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController : MonoBehaviour
{

    public GameObject sun;
    public SaveData saveData;

    // Start is called before the first frame update
    void Start()
    {
        sun.SetActive(saveData.isSunActive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
