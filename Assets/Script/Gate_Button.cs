using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate_Button : MonoBehaviour
{
    public GameObject Gate;
    public bool ispressed;

    Animation anim;

    void Start()
    {
        anim = Gate.GetComponent<Animation>();
    }

    void Update()
    {
        if(ispressed && Gate.transform.rotation == Quaternion.Euler(0,0,0)){
            anim.Play("Gate_motion_open");
        }
        else if(!ispressed && Gate.transform.rotation == Quaternion.Euler(0,90,0)){
            anim.Play("Gate_motion_close");
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            if(ispressed){
            //Debug.Log("AAAAAAA");
                ispressed = false;
            }
            else if(!ispressed){
            //Debug.Log("BBBBBBBBBB");

                ispressed = true;
            }
        }
    }
}
