using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObject : MonoBehaviour
{
    public GameObject[] objs;
    public void Change()
    {
        int ran = Random.Range(0, objs.Length);

        for(int index = 0; index < objs.Length; index++)
        {
            //자식오브젝트의 모든 길이를 다 돌리지만 켜지는건 ran과 index가 동일한 값
            transform.GetChild(index).gameObject.SetActive(ran == index);
        }
    }
}
