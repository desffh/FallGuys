using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    // 캐릭터 오브젝트에 들어가있는 스크립트

    // 캐릭터가 생성되면 (게임방에 들어가면) 자동으로 호출 

    private void Awake()
    {
        SetMouse(false);
    }

    public void SetMouse(bool state)
    {
        Cursor.visible = state;

        // 형변환
        // Convert.ToInt32 -> bool을 1또는 0으로 변환
        // CursorLockMode 는 열거형으로 되어있음 

        // 0 -> None 마우스 자유
        // 1 -> Locked 마우스 잠금
        Cursor.lockState = (CursorLockMode)Convert.ToInt32(!state);
    }
}

