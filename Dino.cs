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
    //이벤트 등장 인스펙터에서 가져오고 싶은함수 직접 지정
    //스테틱도 아니고 변수생성도 아니고 간편하게
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

    //1A. 기본 점프
    void Update()
    {
        if (!GameManager.isLive)
            return;

        //마우스클릭도 추가하려면 두가지방법 or조건추가 하거나 mouse를 Jump로 바꾸면됨
        if ((Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) && isGround)
            rigid.AddForce(Vector2.up * startJumpPower, ForceMode2D.Impulse);

        //addforce를 Update에서 사용하면 문제새여서 옮겼는데 FixedUpdate에서 인풋은 키씹힙 발생 update에서 선언후에 사용
        isJumpkey = Input.GetButton("Jump") || Input.GetMouseButton(0);
    }
    //1B. 롱 점프
    void FixedUpdate()
    {
        if (!GameManager.isLive)
            return;

        if (isJumpkey && !isGround)
        {
            //사운드
            jumpPower = Mathf.Lerp(jumpPower, 0, 0.1f);
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }
    //2. 착지(물리 충돌 이벤트)
    void OnCollisionStay2D(Collision2D collision)
    {
        if (!isGround)
        {
            ChangeAnim(State.Run);
            //사운드
            sound.PlaySound(Sounder.Sfx.Land);
            jumpPower = 1;
        }
        isGround = true;
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        ChangeAnim(State.Jump);
        //사운드
        sound.PlaySound(Sounder.Sfx.Jump);
        isGround = false;
    }
    //3. 장애물 터치(트리거 충돌 이벤트)
    void OnTriggerEnter2D(Collider2D collision)
    {
        //rigid는 비활성화가 없지만 simulate로 물리연산 비활성화 가능
        rigid.simulated = false;
        //사운드
        sound.PlaySound(Sounder.Sfx.Hit);
        ChangeAnim(State.Hit);
        onHit.Invoke();
    }

    //4. 에니메이션
    void ChangeAnim(State state)
    {
        anim.SetInteger("State", (int)state);
    }
}
