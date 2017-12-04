using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class query_ani_con : MonoBehaviour {
    float forwardSpeed;
    float turnSpeed;
    GameObject queryChan;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow)) {
            forwardSpeed = Input.GetAxis("Vertical");
        }
        PlayAnimation();

	}

    void PlayAnimation() {
        if (forwardSpeed > 0f) {
            ChangeAnimation(QueryAnimationController.QueryChanAnimationType.WALK);
        }
    }

    void ChangeAnimation(QueryAnimationController.QueryChanAnimationType animNumber)
    {

        queryChan.GetComponent<QueryAnimationController>().ChangeAnimation(animNumber);

    }
}
