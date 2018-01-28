using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicHuman : MonoBehaviour {

    bool flag = false;
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Zombie") && !flag)
        {
            this.GetComponent<Collider>().gameObject.tag = "Zombie";
            this.GetComponent<Collider>().gameObject.name = "ZombieNow";

            print("col: " + col.gameObject.tag);

            AddZombieComp();
            flag = true;
        }
        else if (col.gameObject.CompareTag("Player") && !flag)
        {
            this.GetComponent<Collider>().gameObject.tag = "Player";
            this.GetComponent<Collider>().gameObject.name = "HumanNow";
            
            print("col: " + col.gameObject.tag);

            AddHumanComp();
            flag = true;
        }
    }

    void AddZombieComp()
    {
        if (!this.GetComponent<ZombieBoid>())
        {
            ZombieBoid zombieScript = this.gameObject.AddComponent<ZombieBoid>();
            zombieScript.enabled = true;

        }
    }
    void AddHumanComp()
    {
        if (!this.GetComponent<HumanBoid>())
        {
            HumanBoid humanboid = this.gameObject.AddComponent<HumanBoid>();
            humanboid.enabled = true;
            humanboid.speed = 10;
            humanboid.maxSpeed = 18;
            humanboid.targetBias = 4;
            humanboid.separationBias = 1;
            humanboid.cohesionBias = 1;
            humanboid.alignmentBias = 1;


        }
        
    }
}
