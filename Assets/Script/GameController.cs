using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Player player;
    public TextMeshProUGUI RubyStonesCounter;
    public static int RubyStonesCollected = 0;
    public int RubyStoneToCollect = 4;
    public GameObject Music;
    public GameObject ChaseMusic;
    public GameObject Dee4;
    public GameObject Dee4Angry;
    public GameObject WinTrigger;

    // Start is called before the first frame update
    void Start()
    {
        RubyStonesCounter.text = RubyStonesCollected + "/" + RubyStoneToCollect + " Ruby Stones";
        Dee4.SetActive(true);
        Dee4Angry.SetActive(false);
        Music.SetActive(true);
        ChaseMusic.SetActive(false);
        WinTrigger.SetActive(false);
        RenderSettings.fog = false;
        RenderSettings.ambientLight = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        RubyStonesCounter.text = RubyStonesCollected + "/" + RubyStoneToCollect + " Ruby Stones";

        if (RubyStonesCollected >= 2) 
        {
            Music.SetActive(false);
            SpoopMode();
        }
    }

    public void CollectRubyStone()
    {
        player.stamina = 100;
        RubyStonesCollected++;
        if (RubyStonesCollected >= RubyStoneToCollect)
        {
            ChaseMusic.SetActive(true);
            RenderSettings.fog = true;
            RenderSettings.fogColor = Color.black;
            WinTrigger.SetActive(true);
        }
    }

    public void SpoopMode() 
    {
        Dee4.SetActive(false);
        Dee4Angry.SetActive(true);
    }
}