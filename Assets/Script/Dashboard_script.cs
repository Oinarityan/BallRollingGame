using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashboard_script : MonoBehaviour
{
    Rigidbody rb;

    public float power;

    public bool plus_x = false;
    public bool minus_x = false;
    public bool plus_z = false;
    public bool minus_z = false;

    public bool trigger = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rb){
            if(!trigger){
                rb.velocity = Vector3.zero;
                trigger = true;
            }
            if(plus_x){
                rb.AddForce(new Vector3(power,0,0));
            }
            else if(minus_x){
                rb.AddForce(new Vector3(-power,0,0));
            }
            else if(plus_z){
                rb.AddForce(new Vector3(0,0,power));
            }
            else if(minus_z){
                rb.AddForce(new Vector3(0,0,-power));
            }
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            rb = other.gameObject.GetComponent<Rigidbody>();
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "Player"){
            rb = null;
        }
    }
}
