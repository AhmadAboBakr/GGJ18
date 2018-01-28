using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFlockManager : MonoBehaviour {
    public List<ZombieBoid> followers;
    public Material queenMaterial;
    public Material zoombieMaterial;
    public GameObject queen;
    public float maxKillTimer=5;
    public float time=5;
    void Awake() {
        followers = new List<ZombieBoid>();
	}

    private void Start()
    {
        
        ChooseTheQueen();
        StartCoroutine(KillAZombie());
    }
    private void Update()
    {
        time -= Time.deltaTime;
    }
    void ChooseTheQueen()
    {
        var newQueen = followers[Random.Range(0, followers.Count)];
        followers.Remove(newQueen);
        queen=newQueen.gameObject;
        queen.transform.parent = this.transform;
        var flockQueen=queen.AddComponent<FlockQueen>();
        queen.GetComponentInChildren<SkinnedMeshRenderer>().material = queenMaterial;
        queen.name = "queen";
        flockQueen.maxSpeed = newQueen.maxSpeed;
        Destroy(newQueen);
    }
    IEnumerator KillAZombie()
    {
        while (followers.Count>0)
        {
            followers[Random.Range(0, followers.Count)].Kill();
            yield return new WaitForSeconds(maxKillTimer/(followers.Count/10));
        }
        var io=queen.GetComponent<InceptionObject>(); ;
        var q = queen.GetComponent<FlockQueen>();
        q.enabled = false;
        io.downVector = Vector3.down;
        io.gravity = 3;

        ///TODO Game over
    }
}
