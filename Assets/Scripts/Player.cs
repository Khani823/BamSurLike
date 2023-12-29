using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    public Scanner scanner;
    //Vector2 = 변수의 타입, inputVec = 변수의 이름
    //변수의 이름을 지을땐 의미를 파악할 수 있도록 짓기

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;
    void Awake() // 초기화 잊지말기
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
    }

    void FixedUpdate() //물리는 FixedUpdate
    {
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    void LateUpdate() // 업데이트가 끝나고 다음프레임으로 넘어가기 직전에 실행되는 생명주기 함수
    {
        anim.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;
        }        
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}
