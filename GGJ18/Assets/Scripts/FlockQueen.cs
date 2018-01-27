﻿using System.Collections;
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
        this.maxSpeed = 13;
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
        this.transform.Rotate(this.transform.up, direction*5, Space.World);
        if (inception.grounded)
        {
            this.rigidBody.velocity = (this.transform.forward) * maxSpeed;
        }
    }
    private void FixedUpdate()
    {
        //Vector2 xz = new Vector2(rigidBody.velocity.x, rigidBody.velocity.z);
        //this.rigidBody.velocity = Vector3.ClampMagnitude(this.rigidBody.velocity,maxSpeed);
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawLine(this.transform.position,this.transform.position+this.rigidBody.velocity);
    //}
}