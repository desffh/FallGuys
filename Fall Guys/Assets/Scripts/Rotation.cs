using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float mouseY;

    [SerializeField] float speed;

    [SerializeField] Transform rotationtransform;

    private void Awake()
    {
        rotationtransform = transform;
    }

    public void OnMouseY()
    {
        mouseY += Input.GetAxisRaw("Mouse X") * speed * Time.deltaTime;
    }

    public void RotateY(Transform transformPosition)
    {
        transformPosition.eulerAngles = new Vector3(0, mouseY, 0);
    }

    private void Update()
    {

    }
}
