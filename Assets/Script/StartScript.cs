using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public Text start;

    private float time;
    public float speed = 1.0f;

    public AudioClip sound1;
    AudioSource audioSource;

    float fadeSpeed = 0.01f;        //透明度が変わるスピードを管理
	float red, green, blue, alfa;   //パネルの色、不透明度を管理

    public bool isFadeOut = false;  //フェードアウト処理の開始、完了を管理するフラグ
	public bool isFadeIn = false;   //フェードイン処理の開始、完了を管理するフラグ
 
	public Image fadeImage;                //透明度を変更するパネルのイメージ
 
 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        red = fadeImage.color.r;
		green = fadeImage.color.g;
		blue = fadeImage.color.b;
		alfa = fadeImage.color.a;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            audioSource.PlayOneShot(sound1);
            //Invoke("Load",0.5f);
            isFadeOut = true;
        }

        if(isFadeOut){
            StartFadeOut();
        }

        start.color = GetAlphaColor(start.color);
    }

    //Alpha値を更新してColorを返す
    Color GetAlphaColor(Color color) {
        time += Time.deltaTime * 5.0f * speed;
        color.a = Mathf.Sin(time) * 0.5f + 0.5f;

        return color;
    }

    void Load(){
    }
 
	void StartFadeOut(){
		fadeImage.enabled = true;  // a)パネルの表示をオンにする
		alfa += fadeSpeed;         // b)不透明度を徐々にあげる
		SetAlpha ();               // c)変更した透明度をパネルに反映する
		if(alfa >= 1){             // d)完全に不透明になったら処理を抜ける
			//isFadeOut = false;
            SceneManager.LoadScene("StageSelect");
		}
	}
 
	void SetAlpha(){
		fadeImage.color = new Color(red, green, blue, alfa);
	}
}
