using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class villian_script : MonoBehaviour {
	public float hp;
    private HealthBar healthB;
	public Animator anim;
	GameObject cam;
    public ParticleSystem healing;
	public float speed;
	float turning;
	public bool kick;
	public bool power;
	bool slide;
    public bool collision;
	public float damage;
	Vector3 mov;
    Vector3 turn;
    public Vector3 contact;

	void OnCollisionStay(Collision col){
		foreach (ContactPoint contact in col.contacts) {
			if (contact.otherCollider.name.Contains ("mummy_medium")) {
				damage += 7;
			}
            if (contact.otherCollider.name.Contains("mummy_small"))
            {
                damage += 4;
            }
        }
		hp -= damage * Time.deltaTime;
	}

	// Use this for initialization
	void Start () {
        healthB = GetComponent<HealthBar>();
        anim = GetComponent<Animator> ();
		cam = GameObject.Find ("Main Camera");
        healing = GetComponentInChildren<ParticleSystem>();
        healing.Stop();
		damage = 0;
		speed = 0f;
		turning = 0f;
        collision = false;
		kick = false;
        turn = new Vector3();
        slide = false;
		power = false;
		hp = 150;
	}

    void Update()
    {
        
		reset ();
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
			power = true;
        }

       
        updateParam();
        

    }

    // Update is called once per frame
    void FixedUpdate () {
		speed = Input.GetAxis ("Vertical");
		turning = Input.GetAxis ("Horizontal");
       
            if (Input.GetKeyDown(KeyCode.Z))
            {
                kick = true;
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                slide = true;
            }

		if (!(anim.GetCurrentAnimatorStateInfo(0).IsName("WAIT04") || anim.GetCurrentAnimatorStateInfo(0).IsName("DAMAGED01") || anim.GetCurrentAnimatorStateInfo(0).IsName("DAMAGED00") || anim.GetCurrentAnimatorStateInfo(0).IsName("WIN00")))
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

    void healthBarWork() {
        // update healthBar parameter
        healthB.currentHealth = hp;

        float actualDMG = damage * Time.deltaTime;
        hp -= actualDMG;
        healthB.takeDamage(actualDMG);
        healthB.Heal(15  * Time.deltaTime);
        this.hp += 15 * Time.deltaTime;
        if (this.hp > 150) {
            this.hp = 150f;
        }
    }

	void updateParam(){
        healthBarWork();

        anim.SetBool ("Kick",kick);
		anim.SetFloat ("Direction", turning, 0.25f, Time.deltaTime);
		anim.SetFloat ("Speed", speed);
		anim.SetBool ("Slide", slide);
		if (hp <= 0) {
			hp = 150;
			transform.position = new Vector3 (-157f, 1.51f, -161.5f);
            this.GetComponent<Score_board>().Reset();

		}
		anim.SetBool ("Power", power);
		damage = 0;
        Vector3
        pos = new Vector3(-157f, 1.51f, -161.5f);


    }

    void Healing_Start()
    {
		healing.time = 3.0f;
		healing.Play();    
    }
    void reset (){
		kick = false;
		slide = false;
		power = false;
	}
}
