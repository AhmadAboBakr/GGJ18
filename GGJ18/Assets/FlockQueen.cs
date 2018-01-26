using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockQueen : MonoBehaviour {
    Rigidbody rigidBody;
	// Use this for initialization
	void Start () {
        rigidBody = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        rigidBody.mass = 200;
	}
}
