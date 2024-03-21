using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleColorChanger : MonoBehaviour
{
    // ��ƼŬ �ý��� ����
    public ParticleSystem particleSystem;
    // ���� ��ȭ�� ������ Ʈ���� ������Ʈ ����
    public GameObject triggerObject;
    // Ʈ���� ������Ʈ�� �������� �� ������ ����
    public Color targetColor;

    private ParticleSystem.Particle[] particles;

    void Start()
    {
        particles = new ParticleSystem.Particle[particleSystem.main.maxParticles];
    }

    void Update()
    {
        // ��ƼŬ �ý��ۿ��� ��ƼŬ ������ ��������
        int numParticlesAlive = particleSystem.GetParticles(particles);

        // Ʈ���� ������Ʈ�� �����ϸ� ���� ����
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

        // ����� ������ ��ƼŬ �ý��ۿ� ����
        particleSystem.SetParticles(particles, numParticlesAlive);
    }

    // Ʈ���� ������Ʈ ���� ��ƼŬ�� �ִ��� Ȯ���ϴ� �Լ�
    bool IsWithinTriggerArea(Vector3 particlePosition)
    {
        return triggerObject.GetComponent<Collider>().bounds.Contains(particlePosition);
    }
}



