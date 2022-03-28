using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerSettings : MonoBehaviour
{
    public static MultiplayerSettings multiplayerSetting;

    public bool delayStart;
    public int maxPlayers;

    public int menuScene;
    public int multiplayerScene;


    private void Awake()
    {
        if(MultiplayerSettings.multiplayerSetting == null)
        {
            MultiplayerSettings.multiplayerSetting = this;
        }
        else
        {
            if (MultiplayerSettings.multiplayerSetting != this)
            {
                Debug.Log("Destroyed LobbyManager");
                Destroy(this.gameObject);
            }
        }
        Debug.Log("Destroyed LobbyManager");
        DontDestroyOnLoad(this.gameObject);

    }
}
