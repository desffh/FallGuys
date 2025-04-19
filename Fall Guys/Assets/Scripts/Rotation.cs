using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float mouseX;

    [SerializeField] float speed;

    [SerializeField] Transform rotationtransform;

    // |-----------------------------------

    [SerializeField] float mouseY;

    private void Awake()
    {
        rotationtransform = transform;
    }

    //  마우스 가로 이동 (좌우)|-----------------------------------

    public void OnMouseY()
    {
        mouseX += Input.GetAxisRaw("Mouse X") * speed * Time.deltaTime;
    }

    public void RotateY(Transform transformPosition)
    {
        transformPosition.eulerAngles = new Vector3(0, mouseX, 0);
    }

    // 마우스 세로 이동 (위아래)|-----------------------------------

    public void OnMouseX()
    {
        mouseY += Input.GetAxisRaw("Mouse Y") * speed * Time.deltaTime;
    }

    public void RotateX(Transform transformPosition)
    {
        mouseY = Mathf.Clamp(mouseY, -65, 65);

        transformPosition.localEulerAngles = new Vector3(-mouseY, 0, 0);
    }
}
