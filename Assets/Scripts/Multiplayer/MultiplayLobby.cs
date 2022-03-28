using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayLobby : MonoBehaviourPunCallbacks
{
    public static MultiplayLobby lobby;

    public GameObject startMatchmaking;
    public GameObject stopMatchmaking;

    private void Awake()
    {
        lobby = this;
    }

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Player connected to Photon Master Server");
        PhotonNetwork.AutomaticallySyncScene = true;
        startMatchmaking.SetActive(true);
    }

    public void OnMatchmakingButtonClicked()
    {
        Debug.Log("MatchMakingClicked");
        PhotonNetwork.JoinRandomRoom();
        startMatchmaking.SetActive(false);
        stopMatchmaking.SetActive(true);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("joining random room");
        CreatingRoom();
    }

    void CreatingRoom()
    {
        int randomRoomName = Random.Range(0, 1000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 4 };
        PhotonNetwork.CreateRoom("Room" + randomRoomName, roomOps);
        Debug.Log("Created new Room");
    }
 
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to create a room failed, there must already be a room with the same name");
        CreatingRoom();      
    }

    public void OnStopMatchmakingButtonClicked()
    {
        stopMatchmaking.SetActive(false);
        startMatchmaking.SetActive(true);

        PhotonNetwork.LeaveRoom();
    }

}
