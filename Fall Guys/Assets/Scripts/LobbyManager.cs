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
        // 씬 이동
        PhotonNetwork.LoadLevel("Game");
    }

    // 방을 생성시키는 함수
    public void OnCreateRoom()
    {
        // 방 옵션을 설정해주는 클래스
        RoomOptions roomOptions = new RoomOptions();

        // 인원 : 2 ~ 4명 들어올 수 있게 설정합니다.

        // 공개 : 룸을 공개할 수 있도록 설정합니다.

        // 활성화 : 방을 보일 수 있도록 설정합니다. 
        
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
            // 룸이 삭제된 경우 
            if(roomInfo.RemovedFromList == true)
            {
                dictionary.TryGetValue(roomInfo.Name, out prefab);

                Destroy(prefab);

                // 더 이상 방이 없으니 딕셔너리에서 제거
                dictionary.Remove(roomInfo.Name);
            }
            // 룸의 정보가 변경되는 경우
            else
            {
                // 룸이 처음 생성되는 경우
                if(dictionary.ContainsKey(roomInfo.Name) == false)
                { 
                    // 키 값이 존재하지 않으면 Instantiate 생성 -> Resources 폴더에서 가져오기

                    // 명시적으로 <GameObject>로 설정해주어야함
                    GameObject clone = Instantiate(Resources.Load<GameObject>("Room"), parentPosition);

                    clone.GetComponent<Information>().View(roomInfo.Name, roomInfo.PlayerCount, roomInfo.MaxPlayers);

                    // 딕셔너리에 추가
                    dictionary.Add(roomInfo.Name, clone);
                }

                // 룸의 정보가 변경되는 경우 (키 값이 존재한다면 - 이미 방이 있다면)
                else
                {
                    dictionary.TryGetValue(roomInfo.Name, out prefab);

                    prefab.GetComponent<Information>().View(roomInfo.Name, roomInfo.PlayerCount, roomInfo.MaxPlayers);
                    
                }
            }
        }
    }
}
