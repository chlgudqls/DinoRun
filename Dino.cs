using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dino : MonoBehaviour
{
    public enum State { Stand, Run, Jump, Hit}
    public float startJumpPower;
    public float jumpPower;
    public bool isGround;
    public bool isJumpkey;
    //�̺�Ʈ ���� �ν����Ϳ��� �������� �����Լ� ���� ����
    //����ƽ�� �ƴϰ� ���������� �ƴϰ� �����ϰ�
    public UnityEvent onHit;

    Rigidbody2D rigid;
    Animator anim;
    Sounder sound;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sound = GetComponent<Sounder>();
    }
    void Start()
    {
        sound.PlaySound(Sounder.Sfx.Reset);
    }

    //1A. �⺻ ����
    void Update()
    {
        if (!GameManager.isLive)
            return;

        //���콺Ŭ���� �߰��Ϸ��� �ΰ������ or�����߰� �ϰų� mouse�� Jump�� �ٲٸ��
        if ((Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) && isGround)
            rigid.AddForce(Vector2.up * startJumpPower, ForceMode2D.Impulse);

        //addforce�� Update���� ����ϸ� ���������� �Ű�µ� FixedUpdate���� ��ǲ�� Ű���� �߻� update���� �����Ŀ� ���
        isJumpkey = Input.GetButton("Jump") || Input.GetMouseButton(0);
    }
    //1B. �� ����
    void FixedUpdate()
    {
        if (!GameManager.isLive)
            return;

        if (isJumpkey && !isGround)
        {
            //����
            jumpPower = Mathf.Lerp(jumpPower, 0, 0.1f);
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }
    //2. ����(���� �浹 �̺�Ʈ)
    void OnCollisionStay2D(Collision2D collision)
    {
        if (!isGround)
        {
            ChangeAnim(State.Run);
            //����
            sound.PlaySound(Sounder.Sfx.Land);
            jumpPower = 1;
        }
        isGround = true;
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        ChangeAnim(State.Jump);
        //����
        sound.PlaySound(Sounder.Sfx.Jump);
        isGround = false;
    }
    //3. ��ֹ� ��ġ(Ʈ���� �浹 �̺�Ʈ)
    void OnTriggerEnter2D(Collider2D collision)
    {
        //rigid�� ��Ȱ��ȭ�� ������ simulate�� �������� ��Ȱ��ȭ ����
        rigid.simulated = false;
        //����
        sound.PlaySound(Sounder.Sfx.Hit);
        ChangeAnim(State.Hit);
        onHit.Invoke();
    }

    //4. ���ϸ��̼�
    void ChangeAnim(State state)
    {
        anim.SetInteger("State", (int)state);
    }
}
