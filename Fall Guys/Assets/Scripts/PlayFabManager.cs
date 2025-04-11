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

        PhotonNetwork.GameVersion = Version; // ���� �����̾�� ���� �÷��� ����

        PhotonNetwork.ConnectUsingSettings(); // ������ ������ ���� 
    }

    public void Fail(PlayFabError playFabError)
    {
        Debug.Log(playFabError.GenerateErrorReport());
    }

    // ������ ������ ����Ǿ��ٸ� 
    public override void OnConnectedToMaster()
    {
        // JoinLobby() : Ư�� �κ� �����Ͽ� �����ϴ� �Լ�
        PhotonNetwork.JoinLobby();


    }

    // �κ� �������� ��  
    public override void OnJoinedLobby()
    {
        // �Ϲ� �� �̵����� �ϸ� AutomaticallySyncScene �� ����� �� ������ ����
        PhotonNetwork.LoadLevel("Lobby");
    }

}
