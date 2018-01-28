using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockQueen : MonoBehaviour {
    Rigidbody rigidBody;
    public float maxSpeed;
    InceptionObject inception;
	// Use this for initialization
	void Start () {
        rigidBody = this.GetComponent<Rigidbody>();
        rigidBody.mass = 2000;
        this.rigidBody.freezeRotation = true;
        this.maxSpeed = 15;
        inception = this.GetComponent<InceptionObject>();
    }

    // Update is called once per frame
    void Update () {
        
        var direction = 0f;
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction--;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction++;
        }
        this.transform.Rotate(this.transform.up, direction*2, Space.World);
        if (inception.grounded)
        {
            this.rigidBody.velocity = (this.transform.forward) * maxSpeed;
        }
    }
}
