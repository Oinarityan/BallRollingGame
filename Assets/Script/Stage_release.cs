using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_release : MonoBehaviour
{
    public static int release_num = 0;

    public GameObject[] StageButton = new GameObject[20];

    void Start()
    {
        //PlayerPrefs.SetInt("release_num",0);  //初期化
        release_num = PlayerPrefs.GetInt("release_num");

        for(int i = 0;i < 20;i++){
            StageButton[i].SetActive(false);
        }

        for(int i = 0;i <= release_num;i++){
            StageButton[i].SetActive(true);
        }
    }

    void Update()
    {

    }
}
