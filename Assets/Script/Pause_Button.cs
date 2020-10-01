using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pause_Button : MonoBehaviour
{
    public Text clear;
	public GameObject select;
	public GameObject next;
	public GameObject Reload;
	public Image back;

    bool trigger = false;

    void Awake(){
        Time.timeScale = 1f;
    }

    void Start()
    {
        clear.enabled = false;
        select.SetActive(false);
        next.SetActive(false);
        Reload.SetActive(false);
        back.enabled = false;
    }

    void Update()
    {
        
    }

    public void pause(){
        if(!ballRun.is_goal){
            if(trigger){
                trigger = false;

                Time.timeScale = 1f;

                clear.enabled = false;
                select.SetActive(false);
                next.SetActive(false);
                Reload.SetActive(false);
                back.enabled = false;
            }
            else if(!trigger){
                trigger = true;

                Time.timeScale = 0f;

                clear.text = "ポーズ";
                clear.enabled = true;
                select.SetActive(true);
                next.SetActive(false);
                Reload.SetActive(true);
                back.enabled = true;
            }
        }

    }
}
