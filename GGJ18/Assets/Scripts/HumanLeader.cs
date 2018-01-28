using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanLeader : MonoBehaviour {
    Rigidbody rigidBody;
    public float maxSpeed;
    InceptionObject inception;
    public float jumpForce = 400;
	// Use this for initialization
	void Start () {
        rigidBody = this.GetComponent<Rigidbody>();
        rigidBody.mass = 1000;
        this.rigidBody.freezeRotation = true;
        this.maxSpeed = 15;
        inception = this.GetComponent<InceptionObject>();
    }

    // Update is called once per frame
    void Update () {
        
        var direction = 0f;
        
        if (Input.GetKey(KeyCode.A))
        {
            direction--;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction++;
        }
        this.transform.Rotate(this.transform.up, direction*2, Space.World);
        //if (inception.grounded)
        {
            this.rigidBody.velocity = (this.transform.forward) * maxSpeed;
        }
    }
    //private void FixedUpdate()
    //{
    //    Jump();

    //}

    void Jump()
    {

        if (Input.GetKeyDown(KeyCode.G))
        {
            this.rigidBody.AddForce(-this.inception.downVector * jumpForce, ForceMode.Impulse);
        }

    }
}
