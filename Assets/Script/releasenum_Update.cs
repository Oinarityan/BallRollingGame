using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class releasenum_Update : MonoBehaviour
{
    public int Stagenum;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            if(Stage_release.release_num < Stagenum){
                Stage_release.release_num = Stagenum;
                PlayerPrefs.SetInt("release_num", Stagenum);
            }
        }
    }
}
