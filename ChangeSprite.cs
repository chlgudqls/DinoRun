using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public Sprite[] sprites;
    SpriteRenderer spriter;
    void Awake()
    {
        spriter = GetComponent<SpriteRenderer>();
        Change(); 
    }

    public void Change()
    {
        //3�ִ°� �����϶���� ���߿� �ϳ� �� ����� ��ũ�� �ȸ��� �̷��� �ϵ��ڵ��̶���� �������ڵ�
        //�������ڵ� �迭�̴ϱ� �迭�� length�� ���
        int ran = Random.Range(0, sprites.Length);
        spriter.sprite = sprites[ran];
    }
}
