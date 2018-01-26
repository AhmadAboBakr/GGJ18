using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockQueen : MonoBehaviour {
    Rigidbody rigidBody;
    public float maxSpeed;
	// Use this for initialization
	void Start () {
        rigidBody = this.GetComponent<Rigidbody>();
        rigidBody.mass = 2000;
        this.rigidBody.freezeRotation = true;
        this.maxSpeed = 13;
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
        this.transform.Rotate(0, direction*5, 0);
        this.rigidBody.AddForce(this.transform.forward*100000);
    }
    private void FixedUpdate()
    {
        Vector2 xz = new Vector2(rigidBody.velocity.x, rigidBody.velocity.z);
        if (xz.sqrMagnitude > maxSpeed)
        {
            xz = xz.normalized * maxSpeed;
            Vector3 velocity = new Vector3(xz.x, rigidBody.velocity.y, xz.y);
            rigidBody.velocity = velocity;
        }
        Debug.Log(rigidBody.velocity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(this.transform.position,this.transform.position+this.rigidBody.velocity);
    }
}
