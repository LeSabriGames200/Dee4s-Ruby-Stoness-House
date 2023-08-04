using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SaveData")]
public class SaveData : ScriptableObject
{
    public bool isSunActive = true;
    public float playerSensitivity;
}
