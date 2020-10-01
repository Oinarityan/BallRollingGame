using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Stage_UI_Mane : MonoBehaviour
{
    public Text clear;
	public GameObject select;
	public GameObject next;
	public GameObject Reload;
	public Image back;

	bool end = false;

    // Start is called before the first frame update
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
        
    }

    void OnTriggerEnter(Collider other){
		if(other.tag == "GOAL" && !end){
			end = true;

			clear.text = "クリア!!!!!";
			clear.enabled = true;
			select.SetActive(true);
			next.SetActive(true);
			Reload.SetActive(true);
			back.enabled = true;
		}
		else if(other.tag == "Trap" && !end){
			end = true;

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

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Bomb" && !end){
			end = true;
			
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
