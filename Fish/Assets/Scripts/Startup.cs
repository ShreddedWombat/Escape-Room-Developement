using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Startup : MonoBehaviour
{
    public GameObject playCam;
    public GameObject player;

    public GameObject menuCam;
    public GameObject hook;
    public GameObject fishFolder;

    // Start is called before the first frame update
    void Start()
    {
        playCam.SetActive(false);
        player.GetComponent<Player_Movement3>().enabled = false;

        fishFolder.SetActive(false);

        //hook.SetActive(false);
        menuCam.SetActive(true);
    }

    
}
