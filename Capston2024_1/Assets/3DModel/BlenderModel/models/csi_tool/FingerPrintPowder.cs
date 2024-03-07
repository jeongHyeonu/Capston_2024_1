using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerPrintPowder : MonoBehaviour
{
    public enum powderType
    {
        ironPowder, // 철가루
        fluorescencePowder, // 형광가루
        none, // 입혀진 가루 없음
    }

    [SerializeField] powderType p_type;

    // 브러시 파우더 통에 붓을 넣을 경우, 타입 지정
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "brushHead")
        {
            FingerPrintBrush brushObj = other.transform.parent.gameObject.GetComponent<FingerPrintBrush>();
            if (brushObj.isEquiped) return; // 이미 붓에 입혀진 경우 실행X

            switch (p_type)
            {
                case powderType.ironPowder:
                    brushObj.p_type = powderType.ironPowder;
                    break;
                case powderType.fluorescencePowder:
                    brushObj.p_type = powderType.fluorescencePowder;
                    break;
            }
        }
    }

    // 브러시 파우더 통을 빠져나갈 경우, 타입 none 으로 지정
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "brushHead")
        {
            FingerPrintBrush brushObj = other.transform.parent.gameObject.GetComponent<FingerPrintBrush>();
            if (brushObj.isEquiped) return; // 이미 붓에 입혀진 경우 실행X

            brushObj.p_type = powderType.none;
        }
    }
}
