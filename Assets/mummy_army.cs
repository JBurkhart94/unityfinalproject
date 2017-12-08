using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class mummy_army : MonoBehaviour {
    Vector3 pos;
    GameObject mum;
    GameObject mum_small;
    public int mum_count;
    public int mum_small_count;
    int gen_counter = 0;


    // Use this for initialization
    void Start () {
		
        mum = GameObject.Find("mummy_medium");
        mum_small = GameObject.Find("mummy_small");
        mum_count = 0;
        mum_small_count = 0;
        gen_counter = 0;
        pos =new Vector3(-164f,1.5f,-153f);
    }

    Vector3 genRandPos() {
        Vector3 rand = new Vector3(pos.x + (float)new System.Random().NextDouble() * 30 - 15, pos.y, pos.z + (float)new System.Random().NextDouble()*30 - 15);
        
        print("Pos rand: " + rand);
        return rand;
    }

	// Update is called once per frame
	void Update () {
        //print("Number of small mummies: " + mum_small_count);

        gen_counter++;
        if (gen_counter > 24) {
            gen_counter -= 24;
            if (mum_count <= 8)
            {

                
                mum_count += 1;
                UnityEngine.Object.Instantiate(mum, genRandPos(), mum.transform.rotation);
            }

            if (mum_small_count <= 10)
            {

                mum_small_count += 1;
                UnityEngine.Object.Instantiate(mum_small, genRandPos(), mum_small.transform.rotation);
            }
        }
   
	}
}
