using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public int count;
    public float speedRate;
    void Start()
    {
        //childCount �ڽĿ�����Ʈ�� ����
        count = transform.childCount;
    }

    void Update()
    {
        //����� �����Ӽ����� ������ ������Ʈ�Լ��� ����ȣ��ǰ��� �׷� �ɸ��½ð��� �����ϰ��� �װɰ��ؼ� ���������Ѵٴ°ǵ�
        //�׷��� Ʈ�������̵��� ���ؼ��� deltatime�� �� �������ߵȴ�
        //�������� ���� ���� ������ �ð��� ���ϱ� ������ �����Ӻ����� �ȴ�
        //�̰� �� �����ӿ� ���� ȣ���ϴ� update�Լ� �����̴� �׷��� ������Ʈ�ȿ��� �̵��ϴ°� detatime�� �ʿ�
        //������Ʈ �Լ��� �� ������ ���� �������� �޶� ������� �ٸ������ִµ� �̸� �����ϱ����ؼ� deltatime�� ���
        if(GameManager.isLive)
        {
            //������ ��Ƽ� �������� �����ٰ���
            float totalSpeed = GameManager.globalSpeed * speedRate * Time.deltaTime * -1f;
            transform.Translate(totalSpeed , 0, 0);
        }
    }
}
