using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Reposition : MonoBehaviour
{
    public UnityEvent onMove;

    //그룹은 위치상관없나
    //실제보이는 자식객체의 위치만 바뀌면되는건지

    //update,fixedupdate 둘다 연산 끝나고 다음 프레임 넘어가기 직전에  호출 후처리 용도
    //주요 로직의 끝난 값을 활용하고 싶을때 카메라 추적 ,돈, 레벨, 경험치, UI
    void LateUpdate()
    {
        //글로벌위치
        if (transform.position.x > -10)
            return;

        //지역 자식위치 변경
        transform.Translate(24, 0, 0, Space.Self);
        onMove.Invoke(); 
    }
}
