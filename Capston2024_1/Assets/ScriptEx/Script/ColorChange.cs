using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    // 투명 오브젝트
    public GameObject transparentObject;
    // 종이 오브젝트
    public GameObject paperObject;
    // 다리미 오브젝트
    public GameObject ironObject;

    // 종이와 다리미가 닿은지 여부
    private bool ironOnPaper = false;
    // 다리미가 투명 오브젝트에 닿은 시간
    private float ironTouchTime = 0f;
    // 다리미가 투명 오브젝트에 닿아 있는 시간 제한
    public float maxIronTouchTime = 5f;
    // 투명 오브젝트의 초기 색
    private Color initialColor;

    void Start()
    {
        // 투명 오브젝트의 초기 색상 저장
        initialColor = transparentObject.GetComponent<Renderer>().material.color;
    }

    void Update()
    {
        // 다리미가 투명 오브젝트에 닿아 있는 동안 시간 측정
        if (ironOnPaper)
        {
            ironTouchTime += Time.deltaTime;
            // 다리미가 일정 시간 이상 닿아 있으면 투명 오브젝트 손상
            if (ironTouchTime >= maxIronTouchTime)
            {
                DamageTransparentObject();
            }
        }
        else
        {
            // 다리미가 투명 오브젝트에 닿지 않은 경우 시간 초기화
            ironTouchTime = 0f;
        }
    }

    void DamageTransparentObject()
    {
        // 투명 오브젝트 손상 (예: 색상 변경)
        transparentObject.GetComponent<Renderer>().material.color = Color.black;
        // 여기에 추가적인 손상 효과를 구현할 수 있음
    }

    // 충돌이 시작되었을 때 호출
    void OnCollisionEnter(Collision collision)
    {
        // 종이와 다리미가 충돌했을 때
        if (collision.gameObject == paperObject && collision.gameObject == ironObject)
        {
            ironOnPaper = true;
        }
    }

    // 충돌이 끝났을 때 호출
    void OnCollisionExit(Collision collision)
    {
        // 종이와 다리미의 충돌이 끝났을 때
        if (collision.gameObject == paperObject && collision.gameObject == ironObject)
        {
            ironOnPaper = false;
        }
    }
}

