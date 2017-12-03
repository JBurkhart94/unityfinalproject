using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScriquery_camera_controller : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }
    public float speed = 10.0F;
    public float rotationSpeed = 100.0F;
    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);


    }
}
