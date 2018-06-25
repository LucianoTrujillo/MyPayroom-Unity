using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {


    public string myColor;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool CompareColors()
    {
        bool correct = false;

        if(myColor == SignManagerGame5.currentColor)
        {
            correct = true;
        }
        return correct;
    }
}
