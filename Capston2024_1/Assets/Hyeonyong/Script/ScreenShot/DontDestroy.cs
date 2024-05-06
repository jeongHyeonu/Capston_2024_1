using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    public TextMeshPro score1;
    public TextMeshPro score2;
    public TextMeshPro score3;
    public TextMeshPro score4;
    public TextMeshPro score5;
    public TextMeshPro score6;
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
        Debug.Log("씬 넘버:"+ num+" 점수1:"+int.Parse(score1.text));
        Debug.Log("씬 넘버:" + num + "점수2:" + int.Parse(score2.text));
        Debug.Log("씬 넘버:" + num + "점수3:" + int.Parse(score3.text));
        Debug.Log("씬 넘버:" + num + "점수4:" + int.Parse(score4.text));
        Debug.Log("씬 넘버:" + num + "점수5:" + int.Parse(score5.text));
        Debug.Log("씬 넘버:" + num + "점수6:" + int.Parse(score6.text));
    }
    // Update is called once per frame
    void Update()
    {

    }
}
