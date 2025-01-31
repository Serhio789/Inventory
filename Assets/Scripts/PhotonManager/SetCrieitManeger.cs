using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;

public class SetCrieitManeger : MonoBehaviourPunCallbacks
{
    public GameObject playerSample;
    public List<Transform> spawnPoints;
    public GameObject[] slots;
    public TextHP hp;

    void Start() => PhotonNetwork.ConnectUsingSettings();

    public override void OnConnectedToMaster()
    {
        RoomOptions roomOptions = new()
        {
            MaxPlayers = 2,
            IsVisible = false
        };
        PhotonNetwork.JoinOrCreateRoom("Test",
                                       roomOptions,
                                       TypedLobby.Default);
    }
    public override void OnJoinedRoom()
    {
        var id = PhotonNetwork.LocalPlayer.ActorNumber;
        Debug.Log(PhotonNetwork.CurrentRoom.PlayerCount);
        if (id > (spawnPoints.Count + 1))
            Debug.LogError("NO SPAWN POINT");
        else
        {
            var clon = PhotonNetwork.Instantiate(playerSample.name, spawnPoints[id - 1].position, Quaternion.identity);
            clon.GetComponent<Inventori>().SetSlots(slots);
            hp.GetComponent<TextHP>().SetPlayer(clon);
        }
    }
}
