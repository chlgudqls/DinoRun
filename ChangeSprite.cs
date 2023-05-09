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
        //3넣는건 지양하라고함 나중에 하나 더 생기면 싱크가 안맞음 이런걸 하드코딩이라고함 안좋은코딩
        //유연한코딩 배열이니까 배열의 length를 사용
        int ran = Random.Range(0, sprites.Length);
        spriter.sprite = sprites[ran];
    }
}
