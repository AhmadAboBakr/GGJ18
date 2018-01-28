using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBoid : MonoBehaviour {
    public ZombieFlockManager manager;
    public float minDistacne;
    public float maxSpeed = 15;
    public float maxDistanceFromSwarm = 4;
    private Vector3 dir;
    Rigidbody rigidBody;
    public float offset = 0;
    InceptionObject inceptionObject;
    Animator animator;
    // Use this for initialization
    void Start () {
        rigidBody = this.GetComponent<Rigidbody>();
        manager.followers.Add(this);
        maxSpeed+= Random.Range(-5,5f);
        inceptionObject = this.GetComponent<InceptionObject>();
        animator = this.GetComponentInChildren<Animator>();
        rigidBody.freezeRotation = true;
        inceptionObject.dead = false;


    }
	
	// Update is called once per frame
	void Update () {
       
        var seek = manager.queen.transform.position - this.transform.position;
        var seperation = Seperate();

        dir = seek.normalized +seperation*.5f;
        var toTarget= (manager.queen.transform.position - this.transform.position);
        if (toTarget.sqrMagnitude > maxDistanceFromSwarm)
        {
            //dir /= toTarget.sqrMagnitude;
        }
        
        rigidBody.AddForce(dir ,ForceMode.Impulse);

        this.transform.LookAt(this.transform.position+this.rigidBody.velocity, -inceptionObject.downVector); ;
	}
    private Vector3 Seperate()
    {
        Vector3 vec=new Vector3();
        var position = this.transform.position;
        int count = 0;
        for (int i = 0; i < manager.followers.Count; i++)
        {
            if (this.manager.followers[i]!=this)
            {
                var tmp= manager.followers[i].transform.position-position;
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

    public void Kill()
    {
        this.gameObject.name = "deadZombie";
        this.inceptionObject.downVector = Vector3.down;
        this.inceptionObject.gravity = 3;
        this.enabled = false;
        animator.enabled = false;
        rigidBody.freezeRotation = false;
        rigidBody.mass = 10000;
        rigidBody.drag = 5;
        rigidBody.angularDrag = 5;
        inceptionObject.dead = true;

    }
    private void FixedUpdate()
    {
        if (this.rigidBody.velocity.sqrMagnitude > maxSpeed)
        {
            rigidBody.velocity = rigidBody.velocity.normalized * maxSpeed;

        }
    }


}
