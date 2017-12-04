using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dude_script : MonoBehaviour {

	Animator anim;
	float speed;
	float turning;
	bool waving;
	bool jumping;
	bool dying;
	bool reviving;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		speed = 0f;
		turning = 0f;
		waving = false;
		jumping = false;
		dying = false;
		reviving = false;
	}
	
	// Update is called once per frame
	void Update () {
		waving = false;
		jumping = false;
		dying = false;
		reviving = false;
		speed = Input.GetAxis ("Vertical");
		turning = Input.GetAxis ("Horizontal");
		anim.SetFloat ("speed", speed);
		anim.SetFloat ("turning", turning, 0.25f, Time.deltaTime);
		if (Input.GetKey ("3")) {
			waving = true;
		}
		if (Input.GetKey ("space")) {
			jumping = true;
		}
		if (Input.GetKey ("1")) {
			dying = true;
		}
		if(Input.GetKey("2")){
			reviving = true;
		}
		anim.SetBool ("waving", waving);
		anim.SetBool ("jumping", jumping);
		anim.SetBool ("dying", dying);
		anim.SetBool ("reviving", reviving);
	
	}
}
