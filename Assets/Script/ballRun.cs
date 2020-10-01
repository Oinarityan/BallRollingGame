using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class ballRun : MonoBehaviour
{
    private float  speed = 50.0f;
	public Vector3 dir;

	bool end = false;
	public bool Maze = false;
	float end_time = 3;

	public static bool is_goal = false;

	//public bool a = false;

	//重力加速度
    const float GRAVITY = 9.81f;    // 追加

	AudioSource audioSource;
	public AudioClip sound1;
	public AudioClip sound2;

	bool trigger1 = false;
	bool trigger2 = false;


 
	// Use this for initialization
	void Start () {
		end = false;
		is_goal = false;

		trigger1 = false;
		trigger2 = false;

		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Maze){
			end = true;
			end_time -= Time.deltaTime;
			if(end_time <= 0){
				end = false;
			}
		}

		dir = Vector3.zero;
 
		// ターゲット端末の縦横の表示に合わせてremapする
		dir.x = Input.acceleration.x;
		dir.y = Input.acceleration.z;
		dir.z = Input.acceleration.y;
 
		// clamp acceleration vector to the unit sphere
		if (dir.sqrMagnitude > 1)
			dir.Normalize();
		
		// Make it move 10 meters per second instead of 10 meters per frame...
		dir *= Time.deltaTime;
 
		// Move object
		//transform.Translate (dir * speed);
		if(!end || Maze_Goal.start){
			Physics.gravity = GRAVITY * dir * speed;
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "GOAL" && !end){
			end = true;	//ゴールかトラップに入ったら動かせなくする
			is_goal = true;

			if(!trigger1){
				audioSource.PlayOneShot(sound1);
				trigger1 = true;
			}

		}
		else if(other.tag == "Trap" && !end){
			end = true;	//ゴールかトラップに入ったら動かせなくする
			is_goal = true;

			if(!trigger2){
				audioSource.PlayOneShot(sound2);
				trigger2 = true;
			}
		}
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Bomb" && !end){
			end = true;	//ゴールかトラップに入ったら動かせなくする
			is_goal = true;

			if(!trigger2){
				audioSource.PlayOneShot(sound2);
				trigger2 = true;
			}
		}
	}
}
