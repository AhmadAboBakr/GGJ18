using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeShitVsible : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Material[] materials = GetComponent<Renderer>().materials;
        foreach (Material thisMaterial in materials)
        {
            Color tempColor = thisMaterial.color;
            tempColor.a = 1f;
            thisMaterial.color = tempColor;

        }
        GetComponent<Renderer>().materials = materials;
    }
}
