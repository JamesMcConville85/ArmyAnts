using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Connect();
	}
    void Connect() {
        PhotonNetwork.ConnectUsingSettings("Multi3PS V1");
    }

    void OnGui() {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }

    void OnJoinedLobby() {
        Debug.Log("OnJoinedLobby");
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed() {
        Debug.Log("OnJoinedLobbyFailed");
        PhotonNetwork.CreateRoom(null);
    }
    void OnJoinedRoom() {
        Debug.Log("Joined");
    }

}
