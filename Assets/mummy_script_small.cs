using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mummy_script_small : MonoBehaviour
{
    public int hp;
    public Animator anim;
    public bool walk;
    public float speed;
    public Vector3 mov;
    bool dead;
    bool atk;
    // Use this for initialization
    void Start()
    {
        hp = 10;
        anim = GetComponent<Animator>();
        walk = false;
        speed = 1f;
        dead = false;
        atk = false;

    }
    void FixedUpdate()
    {
        if (!dead)
        {
            GameObject unity_chan = GameObject.Find("unitychan");
            Vector3 unitychan_pos = unity_chan.transform.position;
            GameObject mumm_gen = GameObject.Find("MummyGenerator");
            mummy_army mum_gen = (mummy_army)mumm_gen.GetComponent<mummy_army>();
            villian_script dam = (villian_script)unity_chan.GetComponent(typeof(villian_script));
            Score_board score = (Score_board)unity_chan.GetComponent<Score_board>();
           
            bool kicked = dam.kick;
            bool powered = dam.power;
            Vector3 my_pos = this.transform.position;
            float dis = Mathf.Pow((unitychan_pos.x - my_pos.x), 2) + Mathf.Pow((unitychan_pos.z - my_pos.z), 2);
            dis = Mathf.Sqrt(dis);
            //print(dis);
            if (kicked && dis < 0.7f)
            {
                hp -= 10;

            }
            if (powered && dis < 3.0f)
            {
                hp -= 30;

            }

            if (dis <= 15f)
            {
                walk = true;
                mov = new Vector3(0, 0, speed * .006f);
                transform.Translate(mov);
                transform.LookAt(GameObject.Find("unitychan").transform);
            }
            else if (atk)
            {
                transform.LookAt(GameObject.Find("unitychan").transform);
            }
            else
            {
                walk = false;
            }

            if (hp < 0 && !dead)
            {
                print("dead");
                dead = true;
                anim.SetBool("Dead", dead);
                Destroy(this.gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + 0.7f);
                score.updatePoints(1);
                mum_gen.mum_small_count -= 1;
            }
            updateParams();
            attackLogic(dis);
        }
    }
    // Update is called once per frame
    void Update()
    {
        updateParams();
    }

    void updateParams()
    {
        anim.SetBool("crippled", walk);
    }

    void attackLogic(float dis)
    {
        if (dis < 0.5f)
        {
            print("Im close");
            atk = true;

        }
        else
        {
            atk = false;
        }
        anim.SetBool("Attack", atk);
    }
}