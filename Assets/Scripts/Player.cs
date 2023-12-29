using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    public Scanner scanner;
    //Vector2 = ������ Ÿ��, inputVec = ������ �̸�
    //������ �̸��� ������ �ǹ̸� �ľ��� �� �ֵ��� ����

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;
    void Awake() // �ʱ�ȭ ��������
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
    }

    void FixedUpdate() //������ FixedUpdate
    {
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    void LateUpdate() // ������Ʈ�� ������ �������������� �Ѿ�� ������ ����Ǵ� �����ֱ� �Լ�
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
