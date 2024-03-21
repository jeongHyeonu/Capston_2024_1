using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleColorChanger : MonoBehaviour
{
    // 파티클 시스템 참조
    public ParticleSystem particleSystem;
    // 색상 변화를 적용할 트리거 오브젝트 참조
    public GameObject triggerObject;
    // 트리거 오브젝트에 접촉했을 때 적용할 색상
    public Color targetColor;

    private ParticleSystem.Particle[] particles;

    void Start()
    {
        particles = new ParticleSystem.Particle[particleSystem.main.maxParticles];
    }

    void Update()
    {
        // 파티클 시스템에서 파티클 데이터 가져오기
        int numParticlesAlive = particleSystem.GetParticles(particles);

        // 트리거 오브젝트에 접촉하면 색상 변경
        if (triggerObject != null && triggerObject.activeSelf)
        {
            for (int i = 0; i < numParticlesAlive; i++)
            {
                if (IsWithinTriggerArea(particles[i].position))
                {
                    particles[i].startColor = targetColor;
                }
            }
        }

        // 변경된 색상을 파티클 시스템에 적용
        particleSystem.SetParticles(particles, numParticlesAlive);
    }

    // 트리거 오브젝트 내에 파티클이 있는지 확인하는 함수
    bool IsWithinTriggerArea(Vector3 particlePosition)
    {
        return triggerObject.GetComponent<Collider>().bounds.Contains(particlePosition);
    }
}



