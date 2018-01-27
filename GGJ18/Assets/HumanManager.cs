using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanManager : MonoBehaviour {
    public List<HumanBoid> followers;
    public Material leaderMaterial;
    public GameObject leader;
	// Use this for initialization
	void Awake() {
        followers = new List<HumanBoid>();
	}

    private void Start()
    {
        ChooseTheLeader();
    }
    public void ChooseTheLeader()
    {
        var newLeader = followers[Random.Range(0, followers.Count)];
        followers.Remove(newLeader);
        leader=newLeader.gameObject;
        leader.transform.parent = this.transform;
        var groupLeader = leader.AddComponent<FlockQueen>();
        //leader.GetComponentInChildren<SkinnedMeshRenderer>().material = queenMaterial;
        leader.name = "Leader";
        groupLeader.maxSpeed = newLeader.maxSpeed;
        Destroy(newLeader);

    }
    void Update () {
		
	}



}
