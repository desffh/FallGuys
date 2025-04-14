using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Photon.Realtime;
using PlayFab.ClientModels;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Information : MonoBehaviourPunCallbacks
{
    // ¹æ Text 
    [SerializeField] Text description;

    [SerializeField] string roomName;

    public void OnConnectRoom()
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public void View(string name, int currentPersonal, int maxPersonal)
    {
        description.text = name + " (" + currentPersonal + " / " + maxPersonal + ")"; 
    }
}