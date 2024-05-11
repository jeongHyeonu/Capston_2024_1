using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LiquidScoreBoard : MonoBehaviour
{
    public TextMeshProUGUI score1;
    public TextMeshProUGUI score2;
    public TextMeshProUGUI score3;
    public TextMeshProUGUI score4;
    public TextMeshProUGUI score5;
    public TextMeshProUGUI score6;
    public TextMeshProUGUI score7;
    public TextMeshProUGUI score8;
    public TextMeshProUGUI score9;
    public TextMeshProUGUI score10;
    public TextMeshProUGUI score11;
    public TextMeshProUGUI score12;
    public TextMeshProUGUI score13;
    public TextMeshProUGUI score14;
    public TextMeshProUGUI score15;

    int num = 0;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        /* int num = int.Parse(score[0, 0].text);
         Debug.Log(int.Parse(score[0, 0].text));

         for( int i=0;i<3;i++)
         {
             for(int j=0;j<2;j++) {
                 Debug.Log(int.Parse(score[i, j].text));
             }
         }*/
    }
    void OnEnable()
    {
        // 델리게이트 체인 추가
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // 델리게이트 체인 제거
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        num++;
        Debug.Log("씬 넘버:" + num + " 점수1:" + int.Parse(score1.text));
        Debug.Log("씬 넘버:" + num + "점수2:" + int.Parse(score2.text));
        Debug.Log("씬 넘버:" + num + "점수3:" + int.Parse(score3.text));
        Debug.Log("씬 넘버:" + num + "점수4:" + int.Parse(score4.text));
        Debug.Log("씬 넘버:" + num + "점수5:" + int.Parse(score5.text));
        Debug.Log("씬 넘버:" + num + "점수6:" + int.Parse(score6.text));
        Debug.Log("씬 넘버:" + num + "점수6:" + int.Parse(score7.text));
        Debug.Log("씬 넘버:" + num + "점수6:" + int.Parse(score8.text));
        Debug.Log("씬 넘버:" + num + "점수6:" + int.Parse(score9.text));
        Debug.Log("씬 넘버:" + num + "점수6:" + int.Parse(score10.text));
        Debug.Log("씬 넘버:" + num + "점수6:" + int.Parse(score11.text));
        Debug.Log("씬 넘버:" + num + "점수6:" + int.Parse(score12.text));
        Debug.Log("씬 넘버:" + num + "점수6:" + int.Parse(score13.text));
        Debug.Log("씬 넘버:" + num + "점수6:" + int.Parse(score14.text));
        Debug.Log("씬 넘버:" + num + "점수6:" + int.Parse(score15.text));
    }
}