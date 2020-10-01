using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate_Button_down : MonoBehaviour
{
    public GameObject Gate;
    public bool ispressed;

    //Animation anim;

    void Start()
    {
        //anim = Gate.GetComponent<Animation>();
    }

    void Update()
    {
        if(ispressed){
            //anim.Play("Gate_motion_down");
            if(Gate.transform.position.y > 0){
                Gate.transform.Translate (0, -0.01f, 0);
            }
        }
        else if(!ispressed){
            if(Gate.transform.position.y < 1){
                Gate.transform.Translate (0, 0.01f, 0);
            }
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            /*
            if(ispressed){
            //Debug.Log("AAAAAAA");
                ispressed = false;
            }
            */
            
            if(!ispressed){
            //Debug.Log("BBBBBBBBBB");

                ispressed = true;
            }
            
        }
    }
}
