using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public float scanRange;
    public LayerMask targetLayer;
    public RaycastHit2D[] targets;
    public Transform nearestTarget;

    void FixedUpdate()
    {
        targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0, targetLayer);
        // CirCleCast 는 원형의 형태로 검증을 하겠다.
        //1.캐스팅 시작위치, 2.원의 반지름, 3.캐스팅 방향, 4. 캐스팅 길이, 5. 대상 레이어
        nearestTarget = GetNearest();
    }

    Transform GetNearest() // 가장 가까운 것을 찾는 함수
    {
        Transform result = null;
        float diff = 100;

        // targets 안에 있는것들을 어떻게 하나하나 비교해서 가장 가까운것을 찾을것인가?

        foreach (RaycastHit2D target in targets)
        {
            Vector3 myPos = transform.position; 
            Vector3 targetPos = target.transform.position;
            float curDiff = Vector3.Distance(myPos, targetPos);

            if (curDiff < diff) // 반복문을 돌며 가져온 거리가 저장된 거리보다 작으면 교체
            {
                diff = curDiff;
                result = target.transform;
            }
        }

        return result;
    }
}
