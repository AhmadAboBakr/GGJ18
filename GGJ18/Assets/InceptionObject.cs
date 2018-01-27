using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InceptionObject : MonoBehaviour {
    public float gravity;
    GameObject lastOne;
    Rigidbody[] bodies;
    Rigidbody body;
    Vector3 downVector;
    // Use this for initialization
	void Start () {
        downVector = Vector3.down;
        bodies = this.GetComponents<Rigidbody>();
        i = 0;
        body = this.GetComponent<Rigidbody>();
        
	}

    void FixedUpdate()
    {
        //bodies[i].velocity += gravity * downVector;
        //i++;
        //if (i > bodies.Length) i = 0;
        body.velocity += gravity * downVector;
    }
    int i;
    private void Update()
    {        

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(this.transform.position,this.transform.position+downVector*10);
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.gameObject !=lastOne&& collision.collider.CompareTag("Ground"))
        {
            lastOne = collision.collider.gameObject;
            downVector = -collision.collider.transform.up;
            this.transform.up = collision.collider.transform.up;
        }
    }
}
