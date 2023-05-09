using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public int count;
    public float speedRate;
    void Start()
    {
        //childCount 자식오브젝트의 갯수
        count = transform.childCount;
    }

    void Update()
    {
        //기기의 프레임성능이 낮으면 업데이트함수가 조금호출되겠지 그럼 걸리는시간이 증가하겠지 그걸곱해서 같아지게한다는건데
        //그래서 트렌스폼이동에 관해서는 deltatime을 꼭 사용해줘야된다
        //프레임이 작은 값에 더많은 시간을 곱하기 때문에 프레임보정이 된다
        //이게 다 프레임에 따라 호출하는 update함수 때문이다 그래서 업데이트안에서 이동하는건 detatime이 필요
        //업데이트 함수가 각 기종에 따른 프레임이 달라서 결과값도 다를수가있는데 이를 보정하기위해서 deltatime을 사용
        if(GameManager.isLive)
        {
            //변수에 담아서 가독성을 높였다고함
            float totalSpeed = GameManager.globalSpeed * speedRate * Time.deltaTime * -1f;
            transform.Translate(totalSpeed , 0, 0);
        }
    }
}
