using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] List<Transform> transformList = new List<Transform>();
    

    private void Awake()
    {
        CreateTransform();    
        
    }


    private void Start()
    {
        int index = PhotonNetwork.CurrentRoom.PlayerCount - 1;

        //Debug.Log(PhotonNetwork.CurrentRoom.PlayerCount);        
        
        // �濡 �����ϸ� Start() ���� -> ĳ���� ����
        PhotonNetwork.Instantiate("Character", transformList[index].position, Quaternion.identity);
    }

    void CreateTransform()
    {
        // Resources�������� �����ص� ��ġ���� �ε�

        for(int i = 0; i < PhotonNetwork.CurrentRoom.MaxPlayers; i++)
        {
            Transform clone = Instantiate(Resources.Load<Transform>("spawn" + i));

            transformList.Add(clone);
        }
    }
}
