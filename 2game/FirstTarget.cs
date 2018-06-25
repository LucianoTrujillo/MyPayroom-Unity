using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTarget : MonoBehaviour {

    
    public GameObject outline;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
       
        if (OutlineManager.index.ToString() == gameObject.name )
        {
           
            outline.SetActive(true);
       
        }
        if (OutlineManager.index.ToString() != gameObject.name)
        {
           
            outline.SetActive(false);

            
        }

        
            
        

    }

    
}
