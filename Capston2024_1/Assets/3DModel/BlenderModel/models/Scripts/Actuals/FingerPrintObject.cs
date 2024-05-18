using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static FingerPrintPowder;

// 지문 검사 대상에 부여할 스크립트
public class FingerPrintObject : MonoBehaviour
{
    public enum ObjectType
    {
        iron,
        flour,
        redFlour,
        none,
    }

    public bool isVisible = false;
    public ObjectType obj_type = ObjectType.none; // 붓으로 문지른게 어떤 색인지 체크

    [SerializeField] powderType answerPowder;
    [SerializeField] TextMeshProUGUI targetScore1;
    [SerializeField] TextMeshProUGUI targetScore2;
    [SerializeField] GameObject rulerAndCard;
    [SerializeField] Material[] mat = new Material[3];

    // 소주병 지문에 트리거 Enter시 또는 흉기 지문에 트리거 Enter시 실행

    //0515 양현용 프리테스트 NPC 텍스트 소환용으로 작성
    public bool onFreeTest = false;//true일때만 사용되도록
    public GameObject HandTrigger;
    npcText failed;
    private bool p_first_Failed = false; //한 번만 불러오도록
   private bool p_second_Failed = false; //한 번만 불러오도록
    public string failed_Text="";
    private int ErrorNum = 1;

    CheckCamera_Freetest checkCamera;
    void Start()
    {
        if (onFreeTest)
        {
            failed = HandTrigger.GetComponent<npcText>();
            checkCamera= GetComponent<CheckCamera_Freetest>();
        }
    }

    //



    private void OnTriggerEnter(Collider other)
    {

        // 지문 안 보이는 상태라면, 붓으로 물체 문지르면 지문 드러남
        if (isVisible==false && other.gameObject.name == "brushHead")
        {
            FingerPrintBrush brushObj = other.transform.parent.gameObject.GetComponent<FingerPrintBrush>();

            // 점수1, 적절한 양의 분말을 묻혔는가?
            if (!brushObj.isStrong) targetScore1.text = "15";

            // 0515 양현용 프리테스트 NPC 텍스트 소환 용도////////////////
            
            if(brushObj.isStrong)
            {
                if (brushObj.p_type != powderType.none && p_first_Failed == false  && onFreeTest==true)
                {
                    //failed_Text += ErrorNum+". "+"분말의 양이 너무 많아요! 너무 많이 묻히면 지문의 융선에 분말이 껴서 분석하기 힘들어요!\n";
                    p_first_Failed = true;

                    //ErrorNum++;
                }
            }
            //////////////////////////////////////////////////////////
            

            // 점수2, 알맞은 색 분말을 묻혔는가?
            if (brushObj.p_type == answerPowder) targetScore2.text = "15";



            // 0515 양현용 프리테스트 NPC 텍스트 소환 용도//////////////
            
            if (brushObj.p_type != answerPowder)
            {
                if (brushObj.p_type != powderType.none && p_second_Failed == false && onFreeTest == true)
                {
                    /*
                    if (answerPowder == powderType.ironPowder)
                    {
                        failed_Text += "이 재질은 검은색 분말을 써야할 것 같아요.";

                    }
                    if (answerPowder == powderType.fluorescencePowder)
                    {
                        failed_Text += "이 재질은 초록색 형광 분말을 써야할 것 같아요.\n";
                    }
                    if (answerPowder == powderType.fluorescenceRedPowder)
                    {
                        failed_Text += "이 재질은 빨간색 형광 분말을 써야할 것 같아요.\n";
                    }*/
                    //failed_Text += ErrorNum + ". " + "검체랑 비슷한 색을 쓰면 지문이 잘 안보여서 사진에 안 담겨요! 반대되는 색을 써야해요!\n";
                    p_second_Failed = true;
                   // ErrorNum++;
                }
            }
            
            if(onFreeTest==true) 
            {
                if (checkCamera.first_check == false || p_first_Failed == true || p_second_Failed == true)
                {
                    if (checkCamera.first_check==false)
                    {
                        //failed_Text = ErrorNum + ". " + "증거물 사진부터 찍어야죠! 기록하는 게 중요하단 거 잊지 마세요!\n" + failed_Text;
                        failed_Text = ErrorNum + ". " + "증거물 사진부터 찍어야죠! 기록하는 게 중요하단 거 잊지 마세요!";
                        ErrorNum++;
                        if (p_first_Failed == true || p_second_Failed == true)
                        {
                            failed_Text += "\n\n";
                        }
                    }

                    if (p_first_Failed == true)
                    {


                        failed_Text += ErrorNum + ". " + "분말의 양이 너무 많아요! 너무 많이 묻히면 지문의 융선에 분말이 껴서 분석하기 힘들어요!";
                        ErrorNum++;
                        if (p_second_Failed == true)
                        {
                            failed_Text += "\n\n";
                        }
                    }

                    if (p_second_Failed == true)
                    {
                        failed_Text += ErrorNum + ". " + "검체랑 비슷한 색을 쓰면 지문이 잘 안보여서 사진에 안 담겨요! 반대되는 색을 써야해요!";
                        ErrorNum++;
                    }
                    failed.FailedPowder(failed_Text);
                }
            }
            
            ///////////////////////////////////////////////////////////

            if (brushObj.p_type == powderType.ironPowder) // 철가루 묻혔으면, 매터리얼 변경
            {
                obj_type = ObjectType.iron;
                this.gameObject.GetComponent<MeshRenderer>().material = mat[0];
            }

            if (brushObj.p_type == powderType.fluorescencePowder) // 형광가루 묻혔으면, 매터리얼 변경
            {
                obj_type = ObjectType.flour;
                this.gameObject.GetComponent<MeshRenderer>().material = mat[1];
            }

            if (brushObj.p_type == powderType.fluorescenceRedPowder) // 적색가루 묻혔으면, 매터리얼 변경
            {
                obj_type = ObjectType.redFlour;
                this.gameObject.GetComponent<MeshRenderer>().material = mat[2];
            }

            // 지문 보이게끔
            this.gameObject.GetComponent<MeshRenderer>().material.DOFade(1f, 2f);
            isVisible = true; // 나중에 테이프로 채취시, 지문이 드러났는지 여부가 true일때 채취 가능
            rulerAndCard?.SetActive(true); // 지문 보이면 자/카드 등장

            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.FLAP_3); // 사운드
        }
    }
}
