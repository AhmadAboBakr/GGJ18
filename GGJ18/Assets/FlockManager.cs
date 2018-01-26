using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour {
    public List<Boid> followers;
    public Material queenMaterial;
    public GameObject queen;
	// Use this for initialization
	void Awake() {
        followers = new List<Boid>();
	}

    private void Start()
    {
        ChooseTheQueen();
    }
    void ChooseTheQueen()
    {
        var newQueen = followers[Random.Range(0, followers.Count)];
        followers.Remove(newQueen);
        queen=newQueen.gameObject;
        Destroy(newQueen);
        queen.transform.parent = this.transform;
        queen.AddComponent<FlockQueen>();
        queen.GetComponent<MeshRenderer>().material = queenMaterial;
        queen.name = "queen";
    }
	void Update () {
		
	}



}
