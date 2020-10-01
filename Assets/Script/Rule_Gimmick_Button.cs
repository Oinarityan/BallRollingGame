using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule_Gimmick_Button : MonoBehaviour
{
    public GameObject Rule;
    public GameObject Gimmick;

    public bool on_ore_off = false;
    bool trigger = false;

    void Start()
    {
        //Rule.SetActive(false);
        //Gimmick.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(on_ore_off){
            if(!trigger){
                Time.timeScale = 0f;
            }
        }
    }

    public void RuleButton(){
        Rule.SetActive(true);
        Gimmick.SetActive(false);
    }

    public void GimmickButton(){
        Rule.SetActive(false);
        Gimmick.SetActive(true);
    }

    public void Ruleback(){
        Rule.SetActive(false);
    }

    public void Gimmickback(){
        Gimmick.SetActive(false);
        trigger = true;
        Time.timeScale = 1f;
    }
}
