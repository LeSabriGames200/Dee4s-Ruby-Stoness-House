using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SunToggle : MonoBehaviour
{

    public SaveData saveData;
    public Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        toggle.isOn = saveData.isSunActive;
    }

    // Update is called once per frame
    void Update()
    {
        if (toggle.isOn)
        {
            saveData.isSunActive = true;
        }else
        {
            saveData.isSunActive = false;
        }
    }
}
