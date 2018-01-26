using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour {
    public FlockManager target;
    public float minDistacne;
    public float maxSpeed = 10;
    public float maxDistanceFromSwarm = 4;
    private Vector3 dir;
    Rigidbody rigidBody;
    public float offset = 0;
    // Use this for initialization
    void Start () {
        rigidBody = this.GetComponent<Rigidbody>();
        target.followers.Add(this);
        maxSpeed+= Random.Range(-5,5f);
	}
	
	// Update is called once per frame
	void Update () {
        var seek = target.queen.transform.position - this.transform.position;
        var seperation = Seperate();

        dir = seek.normalized +seperation*.5f;
        var toTarget= (target.queen.transform.position - this.transform.position);
        if (toTarget.sqrMagnitude > maxDistanceFromSwarm)
        {
            //dir /= toTarget.sqrMagnitude;
        }
        
        rigidBody.AddForce(dir ,ForceMode.Impulse);
        this.transform.forward = this.rigidBody.velocity;
	}
    private Vector3 Seperate()
    {
        Vector3 vec=new Vector3();
        var position = this.transform.position;
        int count = 0;
        for (int i = 0; i < target.followers.Count; i++)
        {
            if (this.target.followers[i]!=this)
            {
                var tmp= target.followers[i].transform.position-position;
                if (tmp.sqrMagnitude<minDistacne)
                {
                    vec += tmp;
                    count++;
                }

            }
        }
        if (count > 0)
            vec /= count;
        return vec;
    }


    private void FixedUpdate()
    {
        Vector2 xz = new Vector2(rigidBody.velocity.x, rigidBody.velocity.z);
        if (xz.sqrMagnitude > maxSpeed)
        {
            xz = xz.normalized * maxSpeed;
            Vector3 velocity = new Vector3(xz.x,rigidBody.velocity.y,xz.y);
            rigidBody.velocity = velocity;
        }

    }
}
