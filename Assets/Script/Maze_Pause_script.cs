using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Maze_Pause_script : MonoBehaviour
{
    public Text text;
	public GameObject select;
	public GameObject Reload;
	public Image back;

    bool trigger = false;

    void Awake(){
        Time.timeScale = 1f;
    }

    void Start()
    {
        text.enabled = false;
        select.SetActive(false);
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

                text.enabled = false;
                select.SetActive(false);
                Reload.SetActive(false);
                back.enabled = false;
            }
            else if(!trigger){
                trigger = true;

                Time.timeScale = 0f;

                text.text = "ポーズ";
                text.enabled = true;
                select.SetActive(true);
                Reload.SetActive(true);
                back.enabled = true;
            }
        }

    }
}
