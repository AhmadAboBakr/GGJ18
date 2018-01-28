using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLossCondition : MonoBehaviour {

    ZombieFlockManager zombieManager;
    HumanManager humanManager;
    GameObject[] humans;
    
    private void Start()
    {
        zombieManager = this.gameObject.GetComponent<ZombieFlockManager>();
        humanManager = this.gameObject.GetComponent<HumanManager>();
    }

    private void Update()
    {
        Debug.Log(zombieManager.followers.Count);
        
        humans = GameObject.FindGameObjectsWithTag("Player");
        //Debug.Log(humans.Length);
        if (zombieManager.followers.Count == 0)
        {
            Debug.Log("Zombies Lose");
            //humans win
        }
        else if (humans.Length<=0)
        {
            //zombies win
            //Doesn't put into consideration neutral humans
            //Debug.Log("Zombies WIN");
        }

        
       
    }
}
