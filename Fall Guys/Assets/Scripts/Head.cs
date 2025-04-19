using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(Rotation))]
public class Head : MonoBehaviour
{
    [SerializeField] Rotation rotation;
    private void Awake()
    {
        rotation = GetComponent<Rotation>();
    }

    private void Update()
    {
        Rotate();
    }


    public void Rotate()
    {
        rotation.OnMouseX();

        rotation.RotateX(transform);
    }
}
