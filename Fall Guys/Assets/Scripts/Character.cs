using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


[RequireComponent(typeof(Rotation))]
public class Character : MonoBehaviourPun
{
    [SerializeField] Camera viewcamera;

    // |------------------------------

    [SerializeField] float speed;

    [SerializeField] Vector3 direction;

    [SerializeField] CharacterController controller;

    // |--------------------------------

    [SerializeField] Rotation rotation;


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
        Vector3 modifiedTransform = 
            transform.TransformDirection(direction * speed * Time.deltaTime);

        controller.Move(direction * Time.deltaTime * speed);
        
    }

    public void Rotate()
    {
        rotation.OnMouseY();

        rotation.RotateY(transform);
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
        OnKeyUpdate();
    }
}
