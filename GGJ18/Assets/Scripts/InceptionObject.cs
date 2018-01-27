using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InceptionObject : MonoBehaviour {
    public float gravity;
    GameObject lastOne;
    Rigidbody[] bodies;
    Rigidbody body;
    public Vector3 downVector;
    public LayerMask layer;
    public bool grounded = false;
    // Use this for initialization
	void Start () {
        downVector = Vector3.down;
        bodies = this.GetComponentsInChildren<Rigidbody>();
        i = 0;
        body = this.GetComponent<Rigidbody>();
        
	}

    void FixedUpdate()
    {

        body.velocity += gravity * downVector;
    }
    int i;
    private void Update()
    {
        Ray ray = new Ray(this.transform.position,downVector);
        if(Physics.Raycast(ray, 3f, layer))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(this.transform.position,this.transform.position+downVector*10);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            if (collision.collider.gameObject != lastOne)
            {
                lastOne = collision.collider.gameObject;
                downVector = -collision.collider.transform.up;

                this.transform.LookAt(collision.gameObject.transform.position, collision.transform.up);
            }
        }
        else if(collision.collider.CompareTag("Bouncy"))
        {
            this.transform.forward = -this.transform.forward;

        }
    }

}
