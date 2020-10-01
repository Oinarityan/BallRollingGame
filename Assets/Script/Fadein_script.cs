using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Fadein_script : MonoBehaviour
{
    float fadeSpeed = 0.01f;        //透明度が変わるスピードを管理
	float red, green, blue, alfa;   //パネルの色、不透明度を管理

	public bool isFadeIn = false;   //フェードイン処理の開始、完了を管理するフラグ
 
	public Image fadeImage;                //透明度を変更するパネルのイメージ

    // Start is called before the first frame update
    void Start()
    {
        red = fadeImage.color.r;
		green = fadeImage.color.g;
		blue = fadeImage.color.b;
		alfa = fadeImage.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if(isFadeIn){
            StartFadeIn();
        }
    }

    void StartFadeIn(){
		alfa -= fadeSpeed;                //a)不透明度を徐々に下げる
		SetAlpha ();                      //b)変更した不透明度パネルに反映する
		if(alfa <= 0){                    //c)完全に透明になったら処理を抜ける
			isFadeIn = false;             
			fadeImage.enabled = false;    //d)パネルの表示をオフにする
		}
	}

    void SetAlpha(){
		fadeImage.color = new Color(red, green, blue, alfa);
	}
}
