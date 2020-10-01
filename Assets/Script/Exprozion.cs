using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exprozion : MonoBehaviour
{   
    public GameObject effect;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "Player"){
            var rb = other.gameObject.GetComponent<Rigidbody>();
			rb.AddExplosionForce(1000, this.gameObject.transform.position, 3);
            //爆破パーティクル
            Instantiate(effect, this.gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    
}
