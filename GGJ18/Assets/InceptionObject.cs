using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InceptionObject : MonoBehaviour {
    public float gravity;
    GameObject lastOne;

    Vector3 downVector;
    Rigidbody rigBody;
    // Use this for initialization
	void Start () {
        downVector = Vector3.down;
        rigBody = this.GetComponent<Rigidbody>();
        if (!rigBody)
            rigBody = this.gameObject.AddComponent<Rigidbody>();
	}

    void FixedUpdate()
    {
        rigBody.velocity += gravity * downVector;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(this.transform.position,this.transform.position+downVector);
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
