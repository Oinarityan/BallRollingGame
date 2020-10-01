using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Maze_Goal : MonoBehaviour
{
    float goaltime = 0f;
    bool goal = false;
    public Text clear;
    public Text Time_text;
    public Text start_countdown;
    public GameObject select;
    float countdown = 3;
    public static bool start = false;

    void Start()
    {
		clear.enabled = false;
		select.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        start_countdown.text = "" + countdown.ToString("f0");
        
        countdown -= Time.deltaTime;
            //Time.timeScale = 0;
        
        if(countdown <= 0){
            Time.timeScale = 1;
            start = true;
			start_countdown.enabled = false;
        }

        Time_text.text = "Time : " + goaltime.ToString("f2");
        if(!goal && start){
            goaltime += Time.deltaTime;
        }

    }

    void OnTriggerEnter(Collider ohter){
        if(ohter.tag == "Maze_goal"){
            goal = true;
            clear.text = "ごおおおおおおおおおおおおおる！！！！！！";
			clear.enabled = true;
    		select.SetActive(true);
        }
    }
}
