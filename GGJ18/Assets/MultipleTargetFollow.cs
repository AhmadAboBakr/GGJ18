using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Camera))]
public class MultipleTargetFollow : MonoBehaviour {

    public List<GameObject> targets;
    public Vector3 offset;
    public GameObject[] startingPlayers;
    private Vector3 velocity;
    public float smoothTime = .5f;
    public float maxZoom = 30;
    public float minZoom = 60f;
    public float zoomLimiter = 50;
    private Camera cam;
    public Vector3 newPosition;

    private void Start()
    {
        
        startingPlayers = GameObject.FindGameObjectsWithTag("Player");
        
        for (int i = 0; i < startingPlayers.Length; i++)
        {
            targets.Add(startingPlayers[i]);
        }

        cam = GetComponent<Camera>();
    }

   

    private void LateUpdate()
    {

        if (targets.Count == 0)
            return;

        Move();
        Zoom();
 
    }

    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, getGreatestDistance()/zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }

    float getGreatestDistance()
    {
        var bounds = new Bounds(targets[0].transform.position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].transform.position);
        }
        if (bounds.size.x > bounds.size.y)
        {
            return bounds.size.x;
        }
        else if (bounds.size.y >= bounds.size.x)
        {
            return bounds.size.y;
        }
        else
            return 0;
    }


    void Move()
    {
        Vector3 centerPoint = getCenterPoint();
        newPosition = centerPoint;
        //transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
        //cam.transform.LookAt(new Vector3(newPosition.x, hamada.center.y, newPosition.z));
        cam.transform.LookAt(centerPoint);
    }

    
    Vector3 getCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].transform.position;
        }

        var bounds = new Bounds(targets[0].transform.position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].transform.position);
        }
        return bounds.center;
    }

}
