using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab.ClientModels;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.UI;
using PlayFab;


public class PlayFabManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField emailInputField;

    [SerializeField] InputField passwordInputField;

    [SerializeField] string Version = "1.0f";

    public void Login()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInputField.text,
            Password = passwordInputField.text,
        };

        PlayFabClientAPI.LoginWithEmailAddress(request, Success, Fail);
    }


    public void Success(LoginResult loginResult)
    {
        PhotonNetwork.AutomaticallySyncScene = false;

        PhotonNetwork.GameVersion = Version; // 같은 버전이어야 같이 플레이 가능

        PhotonNetwork.ConnectUsingSettings(); // 마스터 서버로 진입 
    }

    public void Fail(PlayFabError playFabError)
    {
        Debug.Log(playFabError.GenerateErrorReport());
    }

    // 마스터 서버에 연결되었다면 
    public override void OnConnectedToMaster()
    {
        // JoinLobby() : 특정 로비를 생성하여 진입하는 함수
        PhotonNetwork.JoinLobby();


    }

    // 로비에 접속했을 때  
    public override void OnJoinedLobby()
    {
        // 일반 씬 이동으로 하면 AutomaticallySyncScene 를 사용할 수 없으니 주의
        PhotonNetwork.LoadLevel("Lobby");
    }

}
