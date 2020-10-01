using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bowling_UI : MonoBehaviour
{
    public GameObject[] Pin = new GameObject[10];
    //bool[] is_down = new bool[10];
    public int is_down = 0;
    public bool decision = false;
    float countdown = 3;
    bool trigger = false;

    public Text clear;
	public GameObject select;
	public GameObject next;
	public GameObject Reload;
	public Image back;

    void Start()
    {
        clear.enabled = false;
		select.SetActive(false);
		next.SetActive(false);
		Reload.SetActive(false);
		back.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(decision){
            countdown -= Time.deltaTime;
            if(countdown <= 0 && !trigger){
                trigger = true;    //3秒後に一回だけ判定

                for(int i = 0; i < 10; i++){
                    if(Pin[i].transform.rotation.x >= 60 || Pin[i].transform.rotation.y >= 60
                            || Pin[i].transform.rotation.z >= 60){
                        Debug.Log("aaaa");
                        is_down ++;
                    }
                }

                if(is_down >= 7){
                    clear.text = "クリア!!!!!";
                    clear.enabled = true;
                    select.SetActive(true);
                    next.SetActive(true);
                    Reload.SetActive(true);
                    back.enabled = true;
                }else{
                    clear.text = "失敗...";
                    clear.enabled = true;
                    select.SetActive(true);
                    next.SetActive(true);
                    Reload.SetActive(true);
                    var a = next.GetComponent<Button>();
                    a.interactable = false;
                    back.enabled = true;
                }
            }


        }


    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Decision"){
            decision = true;
		}  
    }
}
