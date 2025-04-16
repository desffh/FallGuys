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
        // photonView.IsMine : ���� ��ü�� �� �ڽ��̶��
        if(photonView.IsMine == false)
        {
            // ������ �ƴ϶�� ������ ī�޶� ��Ȱ��ȭ
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
