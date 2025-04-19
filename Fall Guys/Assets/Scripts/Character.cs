using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


[RequireComponent(typeof(Rotation))]
[RequireComponent(typeof(Mouse))]
public class Character : MonoBehaviourPun
{
    [SerializeField] Camera viewcamera;

    // |------------------------------

    [SerializeField] float speed;

    [SerializeField] Vector3 direction;

    [SerializeField] CharacterController controller;

    // |--------------------------------

    [SerializeField] Rotation rotation;

    // |--------------------------------

    [SerializeField] float gravity;


    private void Awake()
    {
        rotation = GetComponent<Rotation>();

        controller = GetComponent<CharacterController>();
    }

    void Start()
    {
        DesableCamera();
    }


    public void OnKeyUpdate()
    {
        if (photonView.IsMine == false)
        {
            return;
        }

        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");

        direction.Normalize();

        Move();

        Rotate();
    }


    public void Move()
    {

        controller.Move(direction * Time.deltaTime * speed);
        
    }

    public void Rotate()
    {
        rotation.OnMouseY();

        rotation.RotateY(transform);
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
        OnKeyUpdate();
    }
}
