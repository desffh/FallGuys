using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    // ĳ���� ������Ʈ�� ���ִ� ��ũ��Ʈ

    // ĳ���Ͱ� �����Ǹ� (���ӹ濡 ����) �ڵ����� ȣ�� 

    private void Awake()
    {
        SetMouse(false);
    }

    public void SetMouse(bool state)
    {
        Cursor.visible = state;

        // ����ȯ
        // Convert.ToInt32 -> bool�� 1�Ǵ� 0���� ��ȯ
        // CursorLockMode �� ���������� �Ǿ����� 

        // 0 -> None ���콺 ����
        // 1 -> Locked ���콺 ���
        Cursor.lockState = (CursorLockMode)Convert.ToInt32(!state);
    }
}

