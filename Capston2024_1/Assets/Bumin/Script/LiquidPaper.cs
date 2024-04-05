using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidPaper : MonoBehaviour
{
    public Color newColor = Color.blue; // 색 변경할 값 설정 (여기서는 파란색으로 설정)

    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 오브젝트의 레이어가 Liquid인지 확인
        if (collision.gameObject.layer == LayerMask.NameToLayer("Liquid"))
        {
            Renderer renderer = GetComponent<Renderer>();

            // 렌더러 컴포넌트가 존재하고, 색상 변경이 가능한 경우에만 색상 변경
            if (renderer != null && renderer.material != null)
            {
                renderer.material.color = newColor; // 새로운 색으로 변경
            }
        }
    }
}

