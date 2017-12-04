using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class villian_script : MonoBehaviour {
	public Animator anim;
    public ParticleSystem healing;
	public float speed;
	float turning;
	bool kick;
	bool slide;
    public bool collision;
	int damage;
	Vector3 mov;
    Vector3 turn;
    public Vector3 contact;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
        healing = GetComponentInChildren<ParticleSystem>();
        healing.Stop();
		damage = 0;
		speed = 0f;
		turning = 0f;
        collision = false;
		kick = false;
        turn = new Vector3();
        slide = false;
	}

    void Update()
    {
        Collisions();
        if (Input.GetKeyDown(KeyCode.Z))
        {
            kick = true;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            slide = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Healing_Start();
        }
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            Healing_End();
        }

        updateParam();

    }

    // Update is called once per frame
    void FixedUpdate () {
		reset ();
		speed = Input.GetAxis ("Vertical");
		turning = Input.GetAxis ("Horizontal");

		Collisions ();
       
            if (Input.GetKeyDown(KeyCode.Z))
            {
                kick = true;
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                slide = true;
            }

            if (!(anim.GetCurrentAnimatorStateInfo(0).IsName("WAIT04") || anim.GetCurrentAnimatorStateInfo(0).IsName("DAMAGED01") || anim.GetCurrentAnimatorStateInfo(0).IsName("DAMAGED00")))
            {
                if (speed > 0)
                {
                    turn = new Vector3(0, turning * 120 * Time.deltaTime, 0);
                    mov = new Vector3(0, 0, speed * .06f);
                    transform.Rotate(turn);
                    transform.Translate(mov);
                }
                if (speed < 0)
                {
                    turn = new Vector3(0, turning * 40 * Time.deltaTime, 0);
                    mov = new Vector3(0, 0, speed * .01f);
                    transform.Rotate(turn);
                    transform.Translate(mov);
                }
            }
            else
            {
                mov = new Vector3(0, 0, 0);
                transform.Translate(mov);
            }
        
	}


	void updateParam(){
	
		anim.SetBool ("Kick",kick);
		anim.SetFloat ("Direction", turning, 0.25f, Time.deltaTime);
		anim.SetFloat ("Speed", speed);
		anim.SetBool ("Slide", slide);
		anim.SetInteger ("Damage", damage);
	}

	void Collisions(){
		// light damage
		if (Input.GetKeyDown (KeyCode.Q)) {
			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("SLIDE00") || anim.GetCurrentAnimatorStateInfo (0).IsName ("WAIT04")) {
				damage = 10;
			} else {
				damage = 3;
			}
		}
		// heavy damage
		if (Input.GetKeyDown (KeyCode.E)) {
			damage = 10;
		}
	}
    void Healing_Start()
    {
        healing.Play();
        healing.enableEmission = false;
    }
    void Healing_End()
    {
        healing.enableEmission = false;
        healing.Stop();
    }
    void reset (){
		damage = 0;
		kick = false;
		slide = false;
	}

   

    public void collision_trigger_true()
    {
        collision = true;
    }

    public void collision_trigger_false()
    {
        collision = false;
    }

  
}
