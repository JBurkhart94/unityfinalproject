using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision_building : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject.transform.parent.gameObject);
        GameObject unity_chan = GameObject.Find("unitychan");
        villian_script temp = (villian_script)unity_chan.GetComponent(typeof(villian_script));
        //print(temp.speed);
        temp.collision_trigger_true();
        temp.contact = unity_chan.transform.position;
        print(unity_chan.transform.position);
        print(this.transform.position);
        //Bounds bd = new Bounds(this.transform.position,this.transform.);
        //this.gameObject.
    }

    private void OnTriggerExit(Collider other)
    {
        //Destroy(other.gameObject.transform.parent.gameObject);
        GameObject unity_chan = GameObject.Find("unitychan");
        villian_script temp = (villian_script)unity_chan.GetComponent(typeof(villian_script));
        //print(temp.speed);
        temp.collision_trigger_false();
    }

}
