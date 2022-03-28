using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PhotonPlayer : MonoBehaviour
{
    PhotonView PV;
    public GameObject myPlayer;
    private int spawned = 0;


    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PV.IsMine && myPlayer == null)
        {
            int spawnPicker = Random.Range(0, GameSetup.GS.spawnPoints.Length);
            Debug.Log("Player Spawned ------------ " + PV.IsMine);
            Debug.Log(PV.ViewID);
            myPlayer = PhotonNetwork.Instantiate(Path.Combine("PrefabsPhoton", "FPSPlayerPhoton"),
                GameSetup.GS.spawnPoints[spawnPicker].position, GameSetup.GS.spawnPoints[spawnPicker].rotation, 0);

            Debug.Log("Player Spawned ------------ " + PV.IsMine);
            Debug.Log(PV.ViewID);
        }

        
    }
}
