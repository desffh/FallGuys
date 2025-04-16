using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class Character : MonoBehaviourPun
{
    [SerializeField] Camera viewcamera;

    void Start()
    {
        DesableCamera();
    }


    public void DesableCamera()
    {
        // photonView.IsMine : 현재 객체가 나 자신이라면
        if(photonView.IsMine == false)
        {
            // 로컬이 아니라면 본인의 카메라 비활성화
            viewcamera.gameObject.SetActive(false);
        }
        else
        {
            Camera.main.gameObject.SetActive(false);
        }
    }


    void Update()
    {
        
    }
}
