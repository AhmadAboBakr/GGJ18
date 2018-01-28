using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLossCondition : MonoBehaviour {

    ZombieFlockManager zombieManager;
    HumanManager humanManager;

    private void Start()
    {
        zombieManager = this.gameObject.GetComponent<ZombieFlockManager>();
        humanManager = this.gameObject.GetComponent<HumanManager>();
    }

    private void Update()
    {
        if(zombieManager.followers.Count == 0 && humanManager.followers.Count >0)
        {
            //humans win
        }
        else if (humanManager.followers.Count == 0)
        {
            //zombies win
            //Doesn't put into consideration neutral humans
        }
    }
}
