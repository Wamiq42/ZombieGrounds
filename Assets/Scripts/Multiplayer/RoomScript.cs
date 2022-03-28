using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class RoomScript : MonoBehaviourPunCallbacks , IInRoomCallbacks
{
    //Room Info;
    public static RoomScript room;
    private PhotonView PV;

   
    public int currentScene;
    public int multiplayerScene;


  

    private void Awake()
    {
        if(RoomScript.room == null)
        {
            RoomScript.room = this;
        }
        else
        {
            if (RoomScript.room != this)
            {
                Destroy(RoomScript.room.gameObject);
                RoomScript.room = this;
            }
        }
        DontDestroyOnLoad(this.gameObject);
        PV = GetComponent<PhotonView>();
    }
    public override void OnEnable()
    {
        Debug.Log("LoadingNextScene");
        base.OnEnable();
        PhotonNetwork.AddCallbackTarget(this);
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
        
    }

    public override void OnDisable()
    {
        base.OnDisable();
        PhotonNetwork.RemoveCallbackTarget(this);
        SceneManager.sceneLoaded -= OnSceneFinishedLoading;
    }
  
    // Start is called before the first frame update
    void Start()
    {
        
        //readyToCount = false;
        //readyToStart = false;
        //lessThanMaxPlayers = startingTime;
        //atMaxPlayer = 6;
        //timeToStart = startingTime;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("JoinedRoom");
        if (!PhotonNetwork.IsMasterClient)
            return;
        StartGame();
    }
    void StartGame()
    {
        Debug.Log("Game Started");
        PhotonNetwork.LoadLevel(multiplayerScene);
        Debug.Log("SceneChanged");
    }

    void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        currentScene = scene.buildIndex;
        if(currentScene == multiplayerScene)
        {
            CreatePlayer();
        }
    }

    void CreatePlayer()
    {
        Debug.Log("Player Created");
        PhotonNetwork.Instantiate(Path.Combine("PrefabsPhoton", "FPSEmptyPhoton"), transform.position + new Vector3(-7.65f, 0.92f, -15.31f), Quaternion.identity,0);
        Debug.Log("RoomScript Creating Player " + PV.IsMine);
        Debug.Log("RoomScript Creating Player " + PV.ViewID);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
        Debug.Log(otherPlayer.NickName + "has left the Game");
        
    }
}
