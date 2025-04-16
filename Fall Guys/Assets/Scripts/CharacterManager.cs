using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] List<Transform> list;

    [SerializeField] List<Transform> transforms;

    private void Awake()
    {
        // 리스트의 크기를 최대 인원 수 제한만큼으로 설정
        list = new List<Transform>(PhotonNetwork.CurrentRoom.MaxPlayers);
        
    }


    private void Start()
    {      
        Debug.Log(PhotonNetwork.CurrentRoom.PlayerCount);

        for(int i = PhotonNetwork.CurrentRoom.PlayerCount; i < PhotonNetwork.CurrentRoom.MaxPlayers; i++)
        {        
            transforms.Add(list[i]);

            PhotonNetwork.Instantiate("Character", transforms[i].position, Quaternion.identity);
        }
    }
}
