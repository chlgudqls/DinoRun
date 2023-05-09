using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Reposition : MonoBehaviour
{
    public UnityEvent onMove;

    //�׷��� ��ġ�������
    //�������̴� �ڽİ�ü�� ��ġ�� �ٲ��Ǵ°���

    //update,fixedupdate �Ѵ� ���� ������ ���� ������ �Ѿ�� ������  ȣ�� ��ó�� �뵵
    //�ֿ� ������ ���� ���� Ȱ���ϰ� ������ ī�޶� ���� ,��, ����, ����ġ, UI
    void LateUpdate()
    {
        //�۷ι���ġ
        if (transform.position.x > -10)
            return;

        //���� �ڽ���ġ ����
        transform.Translate(24, 0, 0, Space.Self);
        onMove.Invoke(); 
    }
}
