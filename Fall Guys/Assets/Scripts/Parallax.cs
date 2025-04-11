using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
    [SerializeField] Rect rect;

    [SerializeField] RawImage rawImage;

    [SerializeField] float speed;

    private void Awake()
    {
        rawImage = GetComponent<RawImage>();
    }

    void Start()
    {
        rect = rawImage.uvRect;
    }

    void Update()
    {
        rect.x += speed * Time.deltaTime;

        // °»½Å
        rawImage.uvRect = rect;
    }
}
