using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    // instance
    public static NetworkManager instance;

    void Awake()
    {
        // if an instance already exists and if it's not this one, destroy it
        if (instance != null && instance != this)
            gameObject.SetActive(false);
        else
        {
            // set the instnace
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
    }

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();

        
    }

   

    // attempts to CREATE a room
    public void CreateRoom (string roomName)
    {
        PhotonNetwork.CreateRoom(roomName);
    }

    

    // attempts to JOIN a room
    public void JoinRoom ( string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    // changes the scene using Photon's system
    [PunRPC]
    public void ChangeScene ( string sceneName)
    {
        PhotonNetwork.LoadLevel(sceneName);
    }



}
