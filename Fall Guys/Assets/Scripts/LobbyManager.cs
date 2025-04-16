using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Dictionary<string, GameObject> dictionary 
        = new Dictionary<string, GameObject>();

    [SerializeField] Transform parentPosition;

    public override void OnJoinedRoom()
    {
        // �� �̵�
        PhotonNetwork.LoadLevel("Game");
    }

    // ���� ������Ű�� �Լ�
    public void OnCreateRoom()
    {
        // �� �ɼ��� �������ִ� Ŭ����
        RoomOptions roomOptions = new RoomOptions();

        // �ο� : 2 ~ 4�� ���� �� �ְ� �����մϴ�.

        // ���� : ���� ������ �� �ֵ��� �����մϴ�.

        // Ȱ��ȭ : ���� ���� �� �ֵ��� �����մϴ�. 
        
        roomOptions.MaxPlayers = Random.Range(2, 5);

        roomOptions.IsOpen = true;

        roomOptions.IsVisible = true;

        PhotonNetwork.CreateRoom("Room", roomOptions);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        GameObject prefab = null;

        foreach (RoomInfo roomInfo in roomList)
        {
            // ���� ������ ��� 
            if(roomInfo.RemovedFromList == true)
            {
                dictionary.TryGetValue(roomInfo.Name, out prefab);

                Destroy(prefab);

                // �� �̻� ���� ������ ��ųʸ����� ����
                dictionary.Remove(roomInfo.Name);
            }
            // ���� ������ ����Ǵ� ���
            else
            {
                // ���� ó�� �����Ǵ� ���
                if(dictionary.ContainsKey(roomInfo.Name) == false)
                { 
                    // Ű ���� �������� ������ Instantiate ���� -> Resources �������� ��������

                    // ��������� <GameObject>�� �������־����
                    GameObject clone = Instantiate(Resources.Load<GameObject>("Room"), parentPosition);

                    clone.GetComponent<Information>().View(roomInfo.Name, roomInfo.PlayerCount, roomInfo.MaxPlayers);

                    // ��ųʸ��� �߰�
                    dictionary.Add(roomInfo.Name, clone);
                }

                // ���� ������ ����Ǵ� ��� (Ű ���� �����Ѵٸ� - �̹� ���� �ִٸ�)
                else
                {
                    dictionary.TryGetValue(roomInfo.Name, out prefab);

                    prefab.GetComponent<Information>().View(roomInfo.Name, roomInfo.PlayerCount, roomInfo.MaxPlayers);
                    
                }
            }
        }
    }
}
