using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Button_Controller : MonoBehaviour
{
    public string Stagename;

    float fadeSpeed = 0.01f;        //透明度が変わるスピードを管理
	float red, green, blue, alfa;   //パネルの色、不透明度を管理

    public bool isFadeOut1 = false;  //フェードアウト処理の開始、完了を管理するフラグ
    public bool isFadeOut2 = false;
    public bool isFadeOut3 = false;
	public bool isFadeIn = false;   //フェードイン処理の開始、完了を管理するフラグ
 
	public Image fadeImage;                //透明度を変更するパネルのイメージ

    //AudioSource audioSource;
    //public AudioClip sound;

    // Start is called before the first frame update
    void Start()
    {
        red = fadeImage.color.r;
		green = fadeImage.color.g;
		blue = fadeImage.color.b;
		alfa = fadeImage.color.a;

        //audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFadeIn){
            StartFadeIn();
        }
        if(isFadeOut1){
            StartFadeOut1();
        }
        if(isFadeOut2){
            StartFadeOut2();
        }
        if(isFadeOut3){
            StartFadeOut3();
        }
    }

    public void Reload(){
        Time.timeScale = 1.0f;
        //Invoke("RLoad",0.3f);
        isFadeOut3 = true;
    }

    public void StageLoad(){
        Time.timeScale = 1.0f;
        //Invoke("SLoad",0.3f);
        isFadeOut1 = true;
    }

    public void MazeLoad(){
        //Invoke("MLoad",0.3f);
        //StartFadeOut2();
        isFadeOut2 = true;
    }

    void RLoad(){

    }

    void SLoad(){
    }
    
    void MLoad(){
    }

    void StartFadeIn(){
		alfa -= fadeSpeed;                //a)不透明度を徐々に下げる
		SetAlpha ();                      //b)変更した不透明度パネルに反映する
		if(alfa <= 0){                    //c)完全に透明になったら処理を抜ける
			isFadeIn = false;             
			fadeImage.enabled = false;    //d)パネルの表示をオフにする
		}
	}
 
	void StartFadeOut1(){
        //audioSource.PlayOneShot(sound);
		fadeImage.enabled = true;  // a)パネルの表示をオンにする
		alfa += fadeSpeed;         // b)不透明度を徐々にあげる
		SetAlpha ();               // c)変更した透明度をパネルに反映する
		if(alfa >= 1){             // d)完全に不透明になったら処理を抜ける
			//isFadeOut = false;
            SceneManager.LoadScene("Stage" + Stagename);
		}

	}
    void StartFadeOut2(){
        //audioSource.PlayOneShot(sound);
		fadeImage.enabled = true;  // a)パネルの表示をオンにする
		alfa += fadeSpeed;         // b)不透明度を徐々にあげる
		SetAlpha ();               // c)変更した透明度をパネルに反映する
		if(alfa >= 1){             // d)完全に不透明になったら処理を抜ける
			//isFadeOut = false;
            SceneManager.LoadScene("Maze");
		}
	}
    void StartFadeOut3(){
        //audioSource.PlayOneShot(sound);
		fadeImage.enabled = true;  // a)パネルの表示をオンにする
		alfa += fadeSpeed;         // b)不透明度を徐々にあげる
		SetAlpha ();               // c)変更した透明度をパネルに反映する
		if(alfa >= 1){             // d)完全に不透明になったら処理を抜ける
			//isFadeOut = false;
            // 現在のScene名を取得する
            Scene loadScene = SceneManager.GetActiveScene();
            // Sceneの読み直し
            SceneManager.LoadScene(loadScene.name);
		}
	}
 
	void SetAlpha(){
		fadeImage.color = new Color(red, green, blue, alfa);
	}
}
