using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanBoid : MonoBehaviour {
    public GameObject target;
    public Vector3 startingDirection;
    //starting direction will be towards player if it works
    int neighborCount = 0;
    Rigidbody myRigidbody;
    new Vector3 generalDirection;
    public List<GameObject> neighbors = new List<GameObject>();
    public float speed;
    public float maxSpeed = 10;
    public float targetBias, separationBias, cohesionBias, alignmentBias, ArrivalBias;
    public float slowingRadius;

    private void Start()
    {
        
        myRigidbody = this.GetComponent<Rigidbody>();
        startingDirection = new Vector3(Random.Range(1, 3),0, Random.Range(1, 3));
        //myRigidbody.velocity = startingDirection * speed;
        maxSpeed += Random.Range(-5, 5);
    }

    private void FixedUpdate()
    {
        Vector3 tempVector = this.myRigidbody.velocity;
        //Vector3 targetDirection = (target.transform.position - this.transform.position).normalized;
        tempVector += (computeAlignment()*alignmentBias) + (Cohesion()*cohesionBias) + (Separation()*separationBias) + (SeekTarget()*targetBias);
        tempVector = tempVector.normalized;
        
        this.myRigidbody.velocity += tempVector * speed;
        
        this.myRigidbody.velocity = Vector3.ClampMagnitude(this.myRigidbody.velocity, maxSpeed);
    }

    Vector3 SeekTarget()
    {
        Vector3 tempVector = Vector3.zero;
        tempVector = ((target.transform.position - this.transform.position)*speed).normalized;
        return tempVector;
    }

    float Arrival()
    {
        Vector3 desired_velocity = myRigidbody.velocity;
        float distance = Vector3.Distance(target.transform.position, this.transform.position);

        // Check the distance to detect whether the character
        // is inside the slowing area
        if (distance < slowingRadius)
        {
            // Inside the slowing area
            desired_velocity = desired_velocity.normalized * maxSpeed * (distance - 4 / slowingRadius);
            //desired_velocity = 
        }
        else
        {
            // Outside the slowing area.
            desired_velocity = desired_velocity.normalized * maxSpeed;
        }
        return -desired_velocity.magnitude;       
    }

    Vector3 computeAlignment()
    {
        Vector3 tempVector = Vector3.zero;
        if (neighborCount != 0)
        {
            foreach (GameObject neighbor in neighbors)
            {
                tempVector += neighbor.GetComponent<Rigidbody>().velocity;
            }
            tempVector /= neighborCount;
            tempVector = tempVector.normalized;
        }
        return tempVector;
    }

    Vector3 Cohesion()
    {
        Vector3 tempVector = Vector3.zero;
        if(neighborCount != 0)
        {
            foreach (GameObject neighbor in neighbors)
            {
                tempVector += neighbor.transform.position;
            }
            tempVector /= neighborCount;
            tempVector = tempVector.normalized;
        }
        return tempVector;
    }

    Vector3 Separation()
    {
        Vector3 tempVector = Vector3.zero;
        if (neighborCount != 0)
        {
            foreach (GameObject neighbor in neighbors)
            {
                tempVector += (neighbor.transform.position - this.transform.position);
            }
            tempVector *= -1;
            tempVector /= neighborCount;
            tempVector = tempVector.normalized;
        }
        return tempVector;
    }


    



    private void OnTriggerEnter(Collider other)
    {
        if (!neighbors.Contains(other.gameObject) && other.gameObject.tag == "Player")
        {
            neighbors.Add(other.gameObject);
            //updateNeighborCount();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (neighbors.Contains(other.gameObject) && other.gameObject.tag == "Player")
        {
            neighbors.Remove(other.gameObject);
            //updateNeighborCount();
        }
    }
    
    void updateNeighborCount()
    {
        neighborCount = neighbors.Count;
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawLine(this.gameObject.transform.position, -this.myRigidbody.velocity);
    //}
   
}
