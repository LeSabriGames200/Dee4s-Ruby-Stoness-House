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
    public GameObject MiniMap;
    public GameObject Sun;
    public bool GetSecret = false;
    public AudioSource audioSource;
    public AudioClip explode;
    public AudioClip Dee4MadAudio;

    private bool SpoopModeActive = false;
    private bool hasPlayedDee4MadAudio = false;

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
        MiniMap.SetActive(false);
        GetSecret = false;
        SpoopModeActive = false;
        hasPlayedDee4MadAudio = false;
    }

    // Update is called once per frame
    void Update()
    {
        RubyStonesCounter.text = RubyStonesCollected + "/" + RubyStoneToCollect + " Ruby Stones";

        if (RubyStonesCollected >= 2) 
        {
            Music.SetActive(false);
            if (!hasPlayedDee4MadAudio)
            {
                SpoopMode();
                hasPlayedDee4MadAudio = true;
            }
        }

        if(Input.GetKey(KeyCode.Tab))
        {
            MiniMap.SetActive(true);
        }
        else
        {
            MiniMap.SetActive(false);
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
            Destroy(Sun);
        }
    }

    public void SpoopMode() 
    {
        Dee4.SetActive(false);
        Dee4Angry.SetActive(true);
        audioSource.PlayOneShot(Dee4MadAudio);
        SpoopModeActive = true;
    }

    public void GettingTheSecret()
    {
        GetSecret = true;
        audioSource.PlayOneShot(explode);
    }
}